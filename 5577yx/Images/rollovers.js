/* browser detection for rollout menus */
var openId="none";
var doCheck = (document.all!=null);

var BrowserDetect = {
	init: function () {
		this.browser = this.searchString(this.dataBrowser) || "An unknown browser";
		this.version = this.searchVersion(navigator.userAgent)
			|| this.searchVersion(navigator.appVersion)
			|| "an unknown version";
		this.OS = this.searchString(this.dataOS) || "an unknown OS";
	},
	searchString: function (data) {
		for (var i=0;i<data.length;i++)	{
			var dataString = data[i].string;
			var dataProp = data[i].prop;
			this.versionSearchString = data[i].versionSearch || data[i].identity;
			if (dataString) {
				if (dataString.indexOf(data[i].subString) != -1)
					return data[i].identity;
			}
			else if (dataProp)
				return data[i].identity;
		}
	},
	searchVersion: function (dataString) {
		var index = dataString.indexOf(this.versionSearchString);
		if (index == -1) return;
		return parseFloat(dataString.substring(index+this.versionSearchString.length+1));
	},
	dataBrowser: [
		{ 	string: navigator.userAgent,
			subString: "OmniWeb",
			versionSearch: "OmniWeb/",
			identity: "OmniWeb"
		},
		{
			string: navigator.vendor,
			subString: "Apple",
			identity: "Safari"
		},
		{
			prop: window.opera,
			identity: "Opera"
		},
		{
			string: navigator.vendor,
			subString: "iCab",
			identity: "iCab"
		},
		{
			string: navigator.vendor,
			subString: "KDE",
			identity: "Konqueror"
		},
		{
			string: navigator.userAgent,
			subString: "Firefox",
			identity: "Firefox"
		},
		{
			string: navigator.vendor,
			subString: "Camino",
			identity: "Camino"
		},
		{		// for newer Netscapes (6+)
			string: navigator.userAgent,
			subString: "Netscape",
			identity: "Netscape"
		},
		{
			string: navigator.userAgent,
			subString: "MSIE",
			identity: "Explorer",
			versionSearch: "MSIE"
		},
		{
			string: navigator.userAgent,
			subString: "Gecko",
			identity: "Mozilla",
			versionSearch: "rv"
		},
		{ 		// for older Netscapes (4-)
			string: navigator.userAgent,
			subString: "Mozilla",
			identity: "Netscape",
			versionSearch: "Mozilla"
		}
	],
	dataOS : [
		{
			string: navigator.platform,
			subString: "Win",
			identity: "Windows"
		},
		{
			string: navigator.platform,
			subString: "Mac",
			identity: "Mac"
		},
		{
			string: navigator.platform,
			subString: "Linux",
			identity: "Linux"
		}
	]

};
BrowserDetect.init();


/* rollout menu functions */
function getLayer(id) {  
		if (BrowserDetect.browser == "Explorer" || BrowserDetect.browser == "Opera")
   		return document.all[id];
	else if (BrowserDetect.browser == "Netscape")
		return document.layers[id];
	else
		return document.getElementById(id);
}

function showLayer(id) {        
   var get = getLayer(id)
   if (get != null)          
     	if (BrowserDetect.browser != "Netscape")
         	get.style.visibility = "visible";
      	else
         	get.visibility = "show";
}     
  
function hideLayer(id) {
	var get = getLayer(id)        
	if (get != null)        
      if (BrowserDetect.browser != "Netscape")
         get.style.visibility = "hidden";
      else
         get.visibility = "hide";
}

function drillDown(id,div) {
	if (div == 'yes') {
		idDiv = id+'Div';
		if (openId == 'none') {
			showLayer(idDiv);
			openId = id;
			openIdDiv = idDiv;
		} else {
			hideLayer(openIdDiv);
			showLayer(idDiv);
			openId = id;
			openIdDiv = idDiv;
		}
	} else {
		if (openId == 'none') {
		} else {
			hideLayer(openIdDiv);
			openId = 'none';
		}
	}
}

function divRollover(name) {
	openId = name;
	openIdDiv = name+"Div";
	showLayer(openIdDiv);
}

function divRollout(name) {
	hideLayer(name+'Div');
	openId = 'none';
	openIdDiv = 'none';
}

function closeBut(name) {
	hideLayer(name+'Div');
	openId = 'none';
	openIdDiv = 'none';
}

function clearAll(name,count){
	for(i=1;i<=count;i++){
		//alert(name+i);
		hideLayer(name+i+'Div');
	}
}