using Newtonsoft.Json;
using PointLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Windows.Forms;
using System.Xml.Serialization;
using YamlDotNet.Serialization;

namespace FormsApp
{
	
	public partial class PointForm : Form
	{
		private Point[] points = null;
		public PointForm()
		{
			InitializeComponent();
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			points = new Point[5];
			var rnd = new Random();

			for (int i = 0; i < points.Length; i++)
				points[i] = rnd.Next(3) % 2 == 0 ? new Point() : new Point3D();

			listBox.DataSource = null;
			listBox.DataSource = points;
		}

		private void btnSort_Click(object sender, EventArgs e)
		{
			if (points == null) return;
			Array.Sort(points);
			listBox.DataSource = null;
			listBox.DataSource = points;
		}

		private void btnSerialize_Click(object sender, EventArgs e)
		{
			var dlg = new SaveFileDialog();
			dlg.Filter = "SOAP|*.soap|XML|*.xml|JSON|*.json|Binary|*.bin|YAML|*.yaml|My format|*.formatik";

			if (dlg.ShowDialog() != DialogResult.OK) return;

			using (var fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write))
			{
				switch (Path.GetExtension(dlg.FileName))
				{
					case ".bin":
						var bf = new BinaryFormatter();
						bf.Serialize(fs, points);
						break;
					case ".soap":
						var sf = new SoapFormatter();
						sf.Serialize(fs, points);
						break;
					case ".xml":
						var xf = new XmlSerializer(typeof(Point[]), new[] { typeof(Point3D) });
						xf.Serialize(fs, points);
						break;
					case ".json":
						var jf = new JsonSerializer();
						using (var w = new StreamWriter(fs))
							jf.Serialize(w, points);
						break;
					case ".yaml":
						var yf = new SerializerBuilder().Build();
						var yaml = yf.Serialize(points);
						using (var w = new StreamWriter(fs))
							w.Write(yaml);
						break;
				}
			}
		}

		private void btnDeserialize_Click(object sender, EventArgs e)
		{
			var dlg = new OpenFileDialog();
			dlg.Filter = "SOAP|*.soap|XML|*.xml|JSON|*.json|Binary|*.bin|YAML|*.yaml";

			if (dlg.ShowDialog() != DialogResult.OK) return;

			using (var fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read))
			{
				switch (Path.GetExtension(dlg.FileName))
				{
					case ".bin":
						var bf = new BinaryFormatter();
						points = (Point[])bf.Deserialize(fs);
						break;
					case ".soap":
						var sf = new SoapFormatter();
						points = (Point[])sf.Deserialize(fs);
						break;
					case ".xml":
						var xf = new XmlSerializer(typeof(Point[]), new[] { typeof(Point3D) });
						points = (Point[])xf.Deserialize(fs);
						break;
					case ".json":
						using (var r = new StreamReader(fs))
						{
							points = JsonConvert.DeserializeObject<List<object>>(r.ReadToEnd()).Select(
									p => p.ToString().Contains("Z") ? 
										JsonConvert.DeserializeObject<Point3D>(p.ToString()) :
										JsonConvert.DeserializeObject<Point>(p.ToString())
								).ToArray();
						}
						break;
				}
			}
			listBox.DataSource = null;
			listBox.DataSource = points;
		}
	}
}
