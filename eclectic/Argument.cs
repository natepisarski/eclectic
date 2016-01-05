using System;
using System.Collections.Generic;

using HumDrum.Collections;

namespace Eclectic
{
	/// <summary>
	/// Handles command-line arguments, returning a
	/// string for a summary.
	/// </summary>
	public delegate string Handler(string[] args);

	/// <summary>
	/// A description of the actions that should take place
	/// when a certain command-line argument is specified.
	/// </summary>
	public class Argument
	{
		/// <summary>
		/// The flag which causes this argument to
		/// react.
		/// </summary>
		public string Key;

		/// <summary>
		/// The function which handles
		/// the argument.
		/// </summary>
		public Handler Handler;

		/// <summary>
		/// Take arguments until this condition is met
		/// </summary>
		public Predicate<string> Until;


		/// <summary>
		/// Initializes a new instance of the <see cref="Eclectic.Argument"/> class.
		/// Takes the key, which will cause the handler to react to a number of arguments
		/// specified by how long until is true.
		/// </summary>
		/// <param name="key">Key.</param>
		/// <param name="handler">Handler.</param>
		/// <param name="until">Until.</param>
		public Argument(string key, Handler handler, Predicate<string> until)
		{
			Key = key;
			Handler = handler;
			Until = until;
		}

		/// <summary>
		/// Process the specified arguments.
		/// </summary>
		/// <param name="arguments">Arguments.</param>
		public string Process(string[] arguments)
		{
			var applyTo = new List<string> ();


			bool collecting = false;


			foreach (string item in arguments) {
			
				collecting &= Until (item);

				if (collecting && Until (item))
					applyTo.Add (item);

				collecting |= item.Equals (Key);
			}

			return Handler (applyTo.ToArray ());
		}

		/// <summary>
		/// Determines if a given string looks like an argument, based on whether or not
		/// it contains a hyphen. Obviously, this is a terrible way to check for this.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		public static bool IsArgument(string x)
		{
			return x.Contains ("-");
		}
	}
}

