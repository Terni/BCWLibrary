Text files can easily be loaded from an assembly if their BuildAction: EmbeddedResource.
It requires using System.Reflection and System.IO namespaces.
Remember the Resource ID format requires period (.) separators if files are placed inside folders.
To debug, use
foreach (var res in assembly.GetManifestResourceNames) {
   System.Diagnostics.Debug.WriteLine(res);
}


    //Ctrl-M, Ctrl-O will collapse all of the code to its definitions.
    //Ctrl-M, Ctrl-L will expand all of the code (actually, this one toggles it).
    //Ctrl-M, Ctrl-M will expand or collapse a single region