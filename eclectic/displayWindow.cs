using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Eclectic
{
	public partial class displayWindow : Gtk.Window
	{
		Gtk.Table displayTable;

		public displayWindow (int picWidth, int picHeight) :
			base (Gtk.WindowType.Toplevel)
		{
			Build ();
			displayTable = new Gtk.Table ((uint)picWidth/128, (uint)picHeight/128, false);
			this.Add (displayTable);
			this.ShowAll ();
			this.Visible = true;
		}

		/// <summary>
		/// Add the specified image to the form with the given coordinates
		/// </summary>
		/// <param name="img">Image.</param>
		public void Add(Image img, int x, int y)
		{
			Gdk.CairoHelper.SetSourcePixbuf (drawingarea1, new Gdk.Pixbuf ("/tmp/" + x + y + ".gif"), x, y);
		}
	}
}

