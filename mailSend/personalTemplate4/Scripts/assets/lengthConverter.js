// Length Converter 
LengthConverter = Class.create();

LengthConverter.prototype = {
	initialize : function(unit, value){
		this.uv = new Array(); 
		this.uv = {
			"meters" : 1, // ref unit
			"decimeters" : 10,
			"centimeters" : 100,
			"millimeters" : 1000,
			"micrometers" : 1000000,
			"nanometers" : 1000000000,
			"angstroms" : 10000000000,
			"hectometers" : 1/100,
			"kilometers" : 1/1000,
			"inches" : 39.370079,
			"feet" : 3.28084,
			"yards" : 1.093613,
			"miles" : 0.00062137119224,
			"nautical_miles" : 0.000540,
			"cables" : 0.0054
		}
		this.unit = unit; // unit to convert from
		this.value = value; // value to convert
		this.ref = 1 / this.uv[this.unit] * this.value;
	},
	cV : function(unitTo){ // returns value for singel unit
		return this.ref * this.uv[unitTo];
	},
	cVs : function(){ // returns values for all units
		var msg = this.value + " " + this.unit + " => \n";
		for (var i in this.uv) {
			msg += Conv.rounding(this.ref * this.uv[i]) + " " + i + "\n";
		}  
		return msg;
	},
	cVHTML : function(){ // returns html formatted values for all units
		var msg = "<h2>Length Converter</h2>";
		msg += "<p>" + this.value + " " + this.unit + " => </p>";
		msg += "<ul>";
		for (var i in this.uv) {
			msg += "<li>" + Conv.rounding(this.ref * this.uv[i]) + " " + i + "</li>";
		}  
		msg += "</ul>";
		return msg;
	}, 
	c : function(){ // returns an array with calculated values for all units
		var vs = new Array();
		var n = 0;
		for (var i in this.uv) {
			vs[n] = new Array(i,this.ref * this.uv[i]);
			n++;
		}  
		return vs;
	}
}
// Copyright engineeringtoolbox.com