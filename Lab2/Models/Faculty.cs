using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Faculty{
    public string Name {get; set;}
    public string Abbreviation {get; set;}

    public Faculty(string name, string abbreviation){
        Name = name;
        Abbreviation = abbreviation;
    }
}

