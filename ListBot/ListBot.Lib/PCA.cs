using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;

namespace ListBot.Lib
{
	public class PCA
	{
		public static HttpMethod Method { get; set; } = HttpMethod.Post;
		public static string URL { get; set; } = @"http://stat.pcanet.org/ac/directory/directory.cfm";
		public static string RqstByStateFormatString = @"Presbytery=Select+Presbytery&State={0}&orderby=1&submit=Search";

		public PCA()
		{
		}

		public string SearchPcaChurchesByState(string stateCode)
		{
			string responseText = string.Empty;
			using (var waiter = new WebBrowserWaiter.WebBrowserWaiter())
			{
				waiter.Await(wb => wb.Navigate(PCA.URL),
					wb =>
					{
						//var stateCombo = wb.Document.All.Cast<HtmlElement>().First(p => p.Name == "State");
						var stateCombo = wb.Document.All["State"];
						stateCombo.SetAttribute("value", stateCode);

						var submit = wb.Document.All["submit"];
						submit.InvokeMember("click");
					});
				responseText = waiter.Await(wb => wb.DocumentText);
			};

			return responseText;
		}

		public async Task<string> SearchPcaChurchesByStateNoJavaScript(string stateCode)
		{
			var responseText = string.Empty;

			//HttpRequestMessage rqst = new HttpRequestMessage();
			//rqst.Method = PCA.Method;
			//rqst.RequestUri = new Uri(PCA.URL);
			//string content = string.Format(PCA.RqstByStateFormatString, stateCode);
			//rqst.Content = new StringContent(content);
			//var resp = await new HttpClient().SendAsync(rqst);
			//responseText = await resp.Content.ReadAsStringAsync();

			HttpRequestMessage rqst = new HttpRequestMessage();
			rqst.Method = PCA.Method;
			rqst.RequestUri = new Uri(PCA.URL);
			string content = string.Format(PCA.RqstByStateFormatString, stateCode);
			rqst.Content = new StringContent(content);

			var resp = await new HttpClient().SendAsync(rqst);
			responseText = await resp.Content.ReadAsStringAsync();
			return responseText;
		}
	}
}
// Example query to search for PCA churches in FL.
//POST /ac/directory/directory.cfm HTTP/1.1
//Host: stat.pcanet.org
//Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8
//Origin: http://stat.pcanet.org
//Upgrade-Insecure-Requests: 1
//User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.112 Safari/537.36
//Content-Type: application/x-www-form-urlencoded
//Referer: http://stat.pcanet.org/ac/directory/directory.cfm
//Accept-Encoding: gzip, deflate
//Accept-Language: en-US,en;q=0.8
//Cookie: CFID=50222133; CFTOKEN=93415643
//Cache-Control: no-cache
//Postman-Token: 0bd77824-8336-a95c-f4a6-733e98d89e27

//Presbytery=Select+Presbytery&State=FL&orderby=1&submit=Search





//<html>
//    <head>
//        <script type = "text/javascript" src="/CFIDE/scripts/cfform.js"></script>
//        <script type = "text/javascript" src="/CFIDE/scripts/masks.js"></script>
//        <link rel = "STYLESHEET" type="text/css" href="css/main.css">
//        <script type = "text/javascript" >

//			< !--
//	_CF_checkform = function(_CF_this)
//    {
//        //reset on submit
//        _CF_error_exists = false;
//        _CF_error_messages = new Array();
//_CF_error_fields = new Object();
//_CF_FirstErrorField = null;


//        //display error messages and return success
//        if( _CF_error_exists )
//        {
//            if( _CF_error_messages.length > 0 )
//            {
//				// show alert() message
//				_CF_onErrorAlert(_CF_error_messages);
//                // set focus to first form error, if the field supports js focus().
//                if( _CF_this[_CF_FirstErrorField].type == "text" )
//                { _CF_this[_CF_FirstErrorField].focus(); }

//            }
//            return false;
//        }else {
//            return true;
//        }
//    }
////-->
//        </script>
//    </head>
//    <script Language = "JavaScript" >

//		< !--
//function makeWin(url, sWindowName)
//{
//	agent = navigator.userAgent;
//	windowName = sWindowName;
//		params  = "";
//		params += "toolbar=0,";
//		params += "location=0,";
//		params += "directories=0,";
//		params += "status=0,";
//		params += "menubar=0,";
//		params += "scrollbars=0,";
//		params += "resizable=0,";
//		params += "width=430,";
//		params += "height=280";

//	win = window.open(url, windowName, params);

//	if (agent.indexOf("Mozilla/2") != -1 && agent.indexOf("Win") == -1)
//	{
//		win = window.open(url, windowName, params);
//	}
//	if (!win.opener)
//	{
//		win.opener = window;
//	}
//}
////-->
//    </script>
//    <body topmargin = "0" leftmargin="0" link="#800000" vlink="#000080" alink="#800000">
//        <form name = "form" id="form" action="directory.cfm" method="post" onsubmit="return _CF_checkform(this)">
//            <table width = "750" border="0" cellspacing="0" cellpadding="0">
//                <tr>
//                    <td colspan = "3" >

//						< img src="../images/pcaheaderlong.jpg">
//                    </td>

//                </tr>

//            </table>
//            <table width = "900" border="0" cellspacing="0" cellpadding="0">
//                <tr>
//                    <td colspan = "3" > &nbsp;</td>
//                </tr>
//                <tr>
//                    <td colspan = "3" > &nbsp;</td>
//                </tr>
//                <tr>
//                    <td colspan = "3" > &nbsp;</td>
//                </tr>
//                <tr>
//                    <td width = "500" >

//						< strong >

//							< font face="Arial" color="#000080">
//                                <small>&nbsp;Database Updated:&nbsp;</small>
//                            </font>
//                            <br>
//                            <font face = "Arial" color="#800000">
//                                <small>

//&nbsp;April 11, 2016


//                                </font>
//                            </small>
//                            <br>
//                            <strong>
//                                <font face = "Arial" color="#000080">
//                                    <small></small>
//                                </font>
//                            </strong>
//                            <small>
//                                <br>
//                            </small>
//                        </font>
//                    </strong>
//                    <p>
//                        <strong>
//                            <font color = "#0000a0" face="Arial">
//                                <small>&nbsp;
//                                    <a href = "mailto:mjohnston@pcanet.org" > Click to Email Stated Clerk's Office
//                                        <br>

//                                    </a>
//                                </small>
//                            </font>
//                        </strong>
//                        <font size = "1" face="Arial">&nbsp;Thank you for utilizing the PCA online church directory.&nbsp;</font>
//                    </p>

//                </td>
//                <td width = "125" >

//					< img border=0 width=117 height=168 src="../images/bluebook.jpg">

//                </td>
//                <td width = "395" >

//					< b >

//						< font face="Arial" size="3">Handy Companion!</font>
//                    </b>
//                    <br>
//                    <br>
//                    <span style = "font-size: 8.0pt; font-family: Verdana; color: black" >
//This is a complete listing of every PCA church, as well as 
//complete listings for PCA Committee and Agency main contacts, Presbytery WIC
//Presidents, Stated Clerks, and RUF Campus Ministries. 2015 edition.Now in stock!
//</span>
//                    <br>
//                    <br>
//                    <font face = "Arial" size= "2" >

//						< a href= "http://www.cepbookstore.com/p-9569-2015-pca-church-directory.aspx" > Click here to order</a> or call the PCA Bookstore at 1-800-283-1357.
//                    </font>
//                </p>

//            </td>

//        </tr>
//        <tr>
//            <td colspan = "3" style= "font-size:9pt" > &nbsp;
//                <select name = "State" id="State" style="font-size:9pt"  class="txtbox"  size="1" >
//                    <option value = "Select State" selected>Select State</option>
//                      <option value = "AB" > AB </ option >
  
//					  < option value= "AK" > AK </ option >
  
//					  < option value= "AL" > AL </ option >
  
//					  < option value= "AR" > AR </ option >
  
//					  < option value= "AZ" > AZ </ option >
  
//					  < option value= "BC" > BC </ option >
  
//					  < option value= "CA" > CA </ option >
  
//					  < option value= "CO" > CO </ option >
  
//					  < option value= "CT" > CT </ option >
  
//					  < option value= "DC" > DC </ option >
  
//					  < option value= "DE" > DE </ option >
  
//					  < option value= "FL" > FL </ option >
  
//					  < option value= "GA" > GA </ option >
  
//					  < option value= "HI" > HI </ option >
  
//					  < option value= "IA" > IA </ option >
  
//					  < option value= "ID" > ID </ option >
  
//					  < option value= "IL" > IL </ option >
  
//					  < option value= "IN" > IN </ option >
  
//					  < option value= "KS" > KS </ option >
  
//					  < option value= "KY" > KY </ option >
  
//					  < option value= "LA" > LA </ option >
  
//					  < option value= "MA" > MA </ option >
  
//					  < option value= "MD" > MD </ option >
  
//					  < option value= "ME" > ME </ option >
  
//					  < option value= "MI" > MI </ option >
  
//					  < option value= "MN" > MN </ option >
  
//					  < option value= "MO" > MO </ option >
  
//					  < option value= "MS" > MS </ option >
  
//					  < option value= "MT" > MT </ option >
  
//					  < option value= "NB" > NB </ option >
  
//					  < option value= "NC" > NC </ option >
  
//					  < option value= "ND" > ND </ option >
  
//					  < option value= "NE" > NE </ option >
  
//					  < option value= "NH" > NH </ option >
  
//					  < option value= "NJ" > NJ </ option >
  
//					  < option value= "NM" > NM </ option >
  
//					  < option value= "NS" > NS </ option >
  
//					  < option value= "NV" > NV </ option >
  
//					  < option value= "NY" > NY </ option >
  
//					  < option value= "OH" > OH </ option >
  
//					  < option value= "OK" > OK </ option >
  
//					  < option value= "ON" > ON </ option >
  
//					  < option value= "OR" > OR </ option >
  
//					  < option value= "PA" > PA </ option >
  
//					  < option value= "RI" > RI </ option >
  
//					  < option value= "SC" > SC </ option >
  
//					  < option value= "SD" > SD </ option >
  
//					  < option value= "SK" > SK </ option >
  
//					  < option value= "TN" > TN </ option >
  
//					  < option value= "TX" > TX </ option >
  
//					  < option value= "UT" > UT </ option >
  
//					  < option value= "VA" > VA </ option >
  
//					  < option value= "VT" > VT </ option >
  
//					  < option value= "WA" > WA </ option >
  
//					  < option value= "WI" > WI </ option >
  
//					  < option value= "WV" > WV </ option >
  
//					  < option value= "WY" > WY </ option >
  
//					  < option value= "-" > International </ option >
  

//				  </ select >
//				&nbsp;
//Or
//			  &nbsp;
			  
//                <select name = "Presbytery" id="Presbytery" style="font-size:9pt"  class="txtbox"  size="1" >
//                    <option value = "Select Presbytery" selected="selected">Select Presbytery</option>
//                      <option value = "Ascension" > Ascension </ option >
  
//					  < option value= "Blue Ridge" > Blue Ridge</option>
//                      <option value = "Calvary" > Calvary </ option >
  
//					  < option value= "Catawba Valley" > Catawba Valley</option>
//                      <option value = "Central Carolina" > Central Carolina</option>
//                      <option value = "Central Florida" > Central Florida</option>
//                      <option value = "Central Georgia" > Central Georgia</option>
//                      <option value = "Central Indiana" > Central Indiana</option>
//                      <option value = "Chesapeake" > Chesapeake </ option >
  
//					  < option value= "Chicago Metro" > Chicago Metro</option>
//                      <option value = "Covenant" > Covenant </ option >
  
//					  < option value= "Eastern Canada" > Eastern Canada</option>
//                      <option value = "Eastern Carolina" > Eastern Carolina</option>
//                      <option value = "Eastern Pennsylvania" > Eastern Pennsylvania</option>
//                      <option value = "Evangel" > Evangel </ option >
  
//					  < option value= "Fellowship" > Fellowship </ option >
  
//					  < option value= "Georgia Foothills" > Georgia Foothills</option>
//                      <option value = "Grace" > Grace </ option >
  
//					  < option value= "Great Lakes" > Great Lakes</option>
//                      <option value = "Gulf Coast" > Gulf Coast</option>
//                      <option value = "Gulfstream" > Gulfstream </ option >
  
//					  < option value= "Heartland" > Heartland </ option >
  
//					  < option value= "Heritage" > Heritage </ option >
  
//					  < option value= "Houston Metro" > Houston Metro</option>
//                      <option value = "Illiana" > Illiana </ option >
  
//					  < option value= "Iowa" > Iowa </ option >
  
//					  < option value= "James River" > James River</option>
//                      <option value = "Korean Capital" > Korean Capital</option>
//                      <option value = "Korean Central" > Korean Central</option>
//                      <option value = "Korean Eastern" > Korean Eastern</option>
//                      <option value = "Korean Northeastern" > Korean Northeastern</option>
//                      <option value = "Korean Northwest" > Korean Northwest</option>
//                      <option value = "Korean Southeastern" > Korean Southeastern</option>
//                      <option value = "Korean Southern" > Korean Southern</option>
//                      <option value = "Korean Southwest" > Korean Southwest</option>
//                      <option value = "Korean Southwest Orange County" > Korean Southwest Orange County</option>
//                      <option value = "Lowcountry" > Lowcountry </ option >
  
//					  < option value= "Metro Atlanta" > Metro Atlanta</option>
//                      <option value = "Metropolitan New York" > Metropolitan New York</option>
//                    <option value = "Mississippi Valley" > Mississippi Valley</option>
//                      <option value = "Missouri" > Missouri </ option >
  
//					  < option value= "Nashville" > Nashville </ option >
  
//					  < option value= "New Jersey" > New Jersey</option>
//                      <option value = "New River" > New River</option>
//                      <option value = "New York State" > New York State</option>
//                    <option value = "North Florida" > North Florida</option>
//                      <option value = "North Texas" > North Texas</option>
//                      <option value = "Northern California" > Northern California</option>
//                      <option value = "Northern Illinois" > Northern Illinois</option>
//                      <option value = "Northern New England" > Northern New England</option>
//                    <option value = "Northwest Georgia" > Northwest Georgia</option>
//                      <option value = "Ohio" > Ohio </ option >
  
//					  < option value= "Ohio Valley" > Ohio Valley</option>
//                      <option value = "Pacific" > Pacific </ option >
  
//					  < option value= "Pacific Northwest" > Pacific Northwest</option>
//                      <option value = "Palmetto" > Palmetto </ option >
  
//					  < option value= "Pee Dee" > Pee Dee</option>
//                      <option value = "Philadelphia" > Philadelphia </ option >
  
//					  < option value= "Philadelphia Metro West" > Philadelphia Metro West</option>
//                    <option value = "Piedmont Triad" > Piedmont Triad</option>
//                      <option value = "Pittsburgh" > Pittsburgh </ option >
  
//					  < option value= "Platte Valley" > Platte Valley</option>
//                      <option value = "Potomac" > Potomac </ option >
  
//					  < option value= "Providence" > Providence </ option >
  
//					  < option value= "Rocky Mountain" > Rocky Mountain</option>
//                      <option value = "Savannah River" > Savannah River</option>
//                      <option value = "Siouxlands" > Siouxlands </ option >
  
//					  < option value= "South Coast" > South Coast</option>
//                      <option value = "South Florida" > South Florida</option>
//                      <option value = "South Texas" > South Texas</option>
//                      <option value = "Southeast Alabama" > Southeast Alabama</option>
//                      <option value = "Southern Louisiana" > Southern Louisiana</option>
//                      <option value = "Southern New England" > Southern New England</option>
//                    <option value = "Southwest" > Southwest </ option >
  
//					  < option value= "Southwest Florida" > Southwest Florida</option>
//                      <option value = "Suncoast" > Suncoast </ option >
  
//					  < option value= "Susquehanna Valley" > Susquehanna Valley</option>
//                      <option value = "Tennessee Valley" > Tennessee Valley</option>
//                      <option value = "Tidewater" > Tidewater </ option >
  
//					  < option value= "Warrior" > Warrior </ option >
  
//					  < option value= "Western Canada" > Western Canada</option>
//                      <option value = "Western Carolina" > Western Carolina</option>
//                      <option value = "Westminster" > Westminster </ option >
  
//					  < option value= "Wisconsin" > Wisconsin </ option >
  


//				  </ select >
//				&nbsp;

//                <input type = "submit" value="Search" name="submit" class="button">
//            </td>

//        </tr>
//        <tr>
//            <td colspan = "3" > &nbsp;</td>
//        </tr>
//        <tr>
//            <td colspan = "3" style="font-size:9pt">&nbsp;&nbsp;Sort by</td>
//          </tr>
//        <tr>
//            <td colspan = "3" style= "font-size:9pt" > &nbsp;&nbsp;
//                <input name = "orderby" id="orderby"  type="radio" value="1" checked="checked"  />Church Name
//			  </td>
//          </tr>
//        <tr>
//            <td colspan = "3" style= "font-size:9pt" > &nbsp;&nbsp;
//                <input name = "orderby" id="orderby"  type="radio" value="2" />City
//			  </td>
//        </tr>
//        <tr>
//            <td colspan = "3" > &nbsp;</td>
//        </tr>
//        <tr>
//            <td colspan = "3" style="font-size:10pt" align="center">Click on the Church Name to see address information</td>
//        </tr>
//        <tr>
//            <td colspan = "3" > &nbsp;</td>
//        </tr>

//    </table>
//    <table width = "900" border="0" cellspacing="0" cellpadding="0" >
//        <tr>
//            <td>&nbsp;</td>
//            <th class="formtableheaderleft">Church Name</th>
//            <th class="formtableheader">City</th>
//            <th class="formtableheader">State</th>
//            <th class="formtableheader">Phone</th>
//            <th class="formtableheader">EMail</th>
//            <th class="formtableheader">Website</th>
//            <th class="formtableheader">Presbytery</th>
//            <th class="formtableheader">Pastor</th>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=643')" > Areumdown Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Miami</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">305-233-2559</td>
//            <td class="formtable">-</td>
//            <td class="formtable">-</td>
//            <td class="formtable">Korean Southeastern</td>
//            <td class="formtable">Rev.Sunghoon Shin</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=80')" > Auburn Road Presbyterian Church</a>
//            </td>
//            <td class="formtable">Venice</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">941-485-3551</td>
//            <td class="formtable">
//                <a href = "mailto:office@arpca.org" > office@arpca.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.arpca.org" > www.arpca.org </ a >

//			</ td >

//			< td class="formtable">Suncoast</td>
//            <td class="formtable">Rev.Dwight L.Dolby</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4772')" > Bay Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Bonita Springs</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">239-498-9055</td>
//            <td class="formtable">
//                <a href = "mailto:baypres@msn.com" > baypres@msn.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.baypresbonita.com" > www.baypresbonita.com </ a >

//			</ td >

//			< td class="formtable">Suncoast</td>
//            <td class="formtable">Rev.John Boyce Anderson</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1577')" > Boynton Beach Community Church</a>
//            </td>
//            <td class="formtable">Boynton Beach</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">561-733-9400</td>
//            <td class="formtable">
//                <a href = "mailto:bbccmail@bellsouth.net" > bbccmail@bellsouth.net</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.bbcconline.com" > www.bbcconline.com </ a >

//			</ td >

//			< td class="formtable">Gulfstream</td>
//            <td class="formtable">Rev.Dudley R.Hodges</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4469')" > CenterPoint Church</a>
//            </td>
//            <td class="formtable">Tallahassee</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-222-4884</td>
//            <td class="formtable">-</td>
//            <td class="formtable">
//                <a href = "http://www.cptchurch.com" > www.cptchurch.com </ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">Rev.Jonathan Robson</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4353')" > Centerpoint Community Church</a>
//	            </td>
//            <td class="formtable">Ocala</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">352-369-4422</td>
//            <td class="formtable">
//                <a href = "mailto:centerpointcc@earthlink.net" > centerpointcc@earthlink.net</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.CenterPointOcala.com" > www.CenterPointOcala.com </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Charles G.DeBardeleben</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=168')" > Chattahoochee Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Chattahoochee</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-663-2195</td>
//            <td class="formtable">-</td>
//            <td class="formtable">
//                <a href = "http://www.geocities.com/cpcachurch/" > www.geocities.com / cpcachurch /</ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">-</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5514')" > Christ Church East</a>
//	            </td>
//            <td class="formtable">Jacksonville</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">904-262-5588</td>
//            <td class="formtable">
//                <a href = "mailto:kdickerson@christchurch-pca.org" > kdickerson@christchurch-pca.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.christchurch-pca.org" > www.christchurch - pca.org </ a >

//			</ td >

//			< td class="formtable">North Florida</td>
//             <td class="formtable">Rev.Keith Dickerson</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=175')" > Christ Church Mandarin</a>
//	            </td>
//            <td class="formtable">Jacksonville</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">904-262-5588</td>
//            <td class="formtable">
//                <a href = "mailto:ccolson@Christchurch-pca.org" > ccolson@Christchurch-pca.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.christchurch-pca.org" > www.christchurch - pca.org </ a >

//			</ td >

//			< td class="formtable">North Florida</td>
//             <td class="formtable">Rev.Chuck Colson</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5907')" > Christ Church, Intown</a>
//            </td>
//            <td class="formtable">Jacksonville</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">904-517-2297</td>
//            <td class="formtable">
//                <a href = "mailto:dabney@christchurchintown.org" > dabney@christchurchintown.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.christchurchintown.org" > www.christchurchintown.org </ a >

//			</ td >

//			< td class="formtable">North Florida</td>
//             <td class="formtable">Rev.Dave Abney</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1220')" > Christ Community Church</a>
//	            </td>
//            <td class="formtable">Titusville</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">321-269-2478</td>
//            <td class="formtable">
//                <a href = "mailto:admin.cccoffice@gmail.com" > admin.cccoffice@gmail.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.christcommunitytitusville.org" > www.christcommunitytitusville.org </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Dan K.Thompson</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1655')" > Christ Community Church</a>
//	            </td>
//            <td class="formtable">Gainesville</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">352-379-4949</td>
//            <td class="formtable">
//                <a href = "mailto:info@christcommunitychurch.com" > info@christcommunitychurch.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.cccgainesville.com" > www.cccgainesville.com </ a >

//			</ td >

//			< td class="formtable">North Florida</td>
//             <td class="formtable">Rev.Tim Hayse</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5648')" > Christ Community Church of Lake Nona</a>
//            </td>
//            <td class="formtable">Orlando</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">407-414-3018</td>
//            <td class="formtable">
//                <a href = "mailto:info@christcommunitylakenona.com" > info@christcommunitylakenona.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.christcommunitylakenona.com" > www.christcommunitylakenona.com </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.BJ Milgate</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4722')" > Christ Community Presbyterian Church</a>
//            </td>
//            <td class="formtable">Lakeland</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">863-644-7717</td>
//            <td class="formtable">
//                <a href = "mailto:office@ccpclakeland.org" > office@ccpclakeland.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.ccpclakeland.org" > www.ccpclakeland.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.R.Lyle Caswell, Jr.</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1286')" > Christ Community Presbyterian Church</a>
//            </td>
//            <td class="formtable">Clearwater</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">727-530-1770</td>
//            <td class="formtable">
//                <a href = "mailto:info@ccpconline.org" > info@ccpconline.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.ccpconline.org" > www.ccpconline.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.Robert Brubaker</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1344')" > Christ Covenant Church</a>
//	            </td>
//            <td class="formtable">Southwest Ranches</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">954-434-4500</td>
//            <td class="formtable">
//                <a href = "mailto:robin@christcovenant.cc" > robin@christcovenant.cc</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.christcovenant.cc" > www.christcovenant.cc </ a >

//			</ td >

//			< td class="formtable">South Florida</td>
//             <td class="formtable">Rev.Brian L.Kelso</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4647')" > Christ Kingdom Church</a>
//	            </td>
//            <td class="formtable">Orlando</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">407-637-9990</td>
//            <td class="formtable">
//                <a href = "mailto:info@christkingdom.org" > info@christkingdom.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.christkingdom.org" > www.christkingdom.org </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Michael Scott Puckett</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4149')" > Christ the King PCA Church</a>
//	            </td>
//            <td class="formtable">Seminole</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">727-394-0787</td>
//            <td class="formtable">
//                <a href = "mailto:hisrock@live.com" > hisrock@live.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.ctkpcaseminole.com" > www.ctkpcaseminole.com </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.Peter B.LaPointe</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4279')" > Christ the King Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Vero Beach</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">772-978-5848</td>
//            <td class="formtable">
//                <a href = "mailto:info@ctkvb.org" > info@ctkvb.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.ctkvb.org" > www.ctkvb.org </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">-</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5856')" > Christ the King Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Port St Lucie</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">561-596-0332</td>
//            <td class="formtable">
//                <a href = "mailto:christthekingpsl@gmail.com" > christthekingpsl@gmail.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.christthekingpsl.com" > www.christthekingpsl.com </ a >

//			</ td >

//			< td class="formtable">Gulfstream</td>
//            <td class="formtable">Rev.Jonathon Christian Cunningham</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5894')" > Christ United Fellowship Orlando</a>
//            </td>
//            <td class="formtable">Orlando</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">407-454-4704</td>
//            <td class="formtable">
//                <a href = "mailto:maitcheson72@gmail.com" > maitcheson72@gmail.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://christunitedfellowship.com" > christunitedfellowship.com </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Mike Aitcheson</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5474')" > Circle PCA</a>
//            </td>
//            <td class="formtable">Pace</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-748-3939</td>
//            <td class="formtable">
//                <a href = "mailto:cwilcox@circlepca.org" > cwilcox@circlepca.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.circlepca.org" > www.circlepca.org </ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">Rev.Clifton David Wilcox</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4820')" > CityChurch </ a >

//			</ td >

//			< td class="formtable">Ft.Lauderdale</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">954-634-2489</td>
//            <td class="formtable">
//                <a href = "mailto:info@citychurchftl.com" > info@citychurchftl.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.citychurchftl.com" > www.citychurchftl.com </ a >

//			</ td >

//			< td class="formtable">South Florida</td>
//             <td class="formtable">Rev.Fredrick B.Hunter, III</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1383')" > Community Presbyterian Church</a>
//	            </td>
//            <td class="formtable">McIntosh</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">352-591-3663</td>
//            <td class="formtable">
//                <a href = "mailto:cpcscott@cox.net" > cpcscott@cox.net</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.mcintoshcpc.com" > www.mcintoshcpc.com </ a >

//			</ td >

//			< td class="formtable">North Florida</td>
//             <td class="formtable">Rev.Scott A.Simmons</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=220')" > Community Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Live Oak</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">386-362-2323</td>
//            <td class="formtable">-</td>
//            <td class="formtable">
//                <a href = "http://cpcliveoak.org" > cpcliveoak.org </ a >

//			</ td >

//			< td class="formtable">North Florida</td>
//             <td class="formtable">Rev.Joseph Hatcher</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=225')" > Concord Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Gulf Breeze</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-932-6243</td>
//            <td class="formtable">
//                <a href = "mailto:admin@concrdpres.com" > admin@concrdpres.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.concordpres.com" > www.concordpres.com </ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">Dr.Jonathan Becker</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=227')" > Coquina Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Ormond Beach</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">386-677-2041</td>
//            <td class="formtable">
//                <a href = "mailto:info@coquinachurchpca.org" > info@coquinachurchpca.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.coquinachurchpca.org" > www.coquinachurchpca.org </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Cornelius J.Ganzel, Jr.</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=228')" > Coral Ridge Presbyterian Church</a>
//            </td>
//            <td class="formtable">Ft.Lauderdale</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">954-771-8840</td>
//            <td class="formtable">
//                <a href = "mailto:crpc@crpc.org" > crpc@crpc.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.crpc.org" > www.crpc.org </ a >

//			</ td >

//			< td class="formtable">South Florida</td>
//             <td class="formtable">-</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1542')" > Cornerstone of Lakewood Ranch</a>
//            </td>
//            <td class="formtable">Bradenton</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">941-907-3939</td>
//            <td class="formtable">
//                <a href = "mailto:office@onthecorner.org" > office@onthecorner.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.onthecorner.org" > www.onthecorner.org </ a >

//			</ td >

//			< td class="formtable">Suncoast</td>
//            <td class="formtable">Rev.Philip Woods</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1524')" > Cornerstone Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Palm Beach Gardens</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">561-775-7070</td>
//            <td class="formtable">
//                <a href = "mailto:drjjb1@hotmail.com" > drjjb1@hotmail.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.cornerstone-presbyterian.org" > www.cornerstone - presbyterian.org </ a >

//			</ td >

//			< td class="formtable">Gulfstream</td>
//            <td class="formtable">Dr.John J.Barber</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4122')" > Cornerstone Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Destin</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-654-7133</td>
//            <td class="formtable">
//                <a href = "mailto:drob9944@aol.com" > drob9944@aol.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.cornerstonepcadestin.org" > www.cornerstonepcadestin.org </ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">Rev.G.Dewey Roberts</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=231')" > Cornerstone Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Tallahassee</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-668-9504</td>
//            <td class="formtable">-</td>
//            <td class="formtable">-</td>
//            <td class="formtable">Gulf Coast</td>
//            <td class="formtable">Rev.James E.Watson</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=151')" > Cornerstone Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Lutz</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">813-962-3584</td>
//            <td class="formtable">
//                <a href = "mailto:cornerstonelutz@verizon.net" > cornerstonelutz@verizon.net</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.cpclutz.org" > www.cpclutz.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.Robert D.Byrne</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=277')" > Covenant Church of Naples</a>
//            </td>
//            <td class="formtable">Naples</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">239-597-3464</td>
//            <td class="formtable">
//                <a href = "mailto:info@covenantnaples.com" > info@covenantnaples.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.covenantnaples.com" > www.covenantnaples.com </ a >

//			</ td >

//			< td class="formtable">Suncoast</td>
//            <td class="formtable">Dr.Robert A.Petterson</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=246')" > Covenant Life Presbyterian Church</a>
//            </td>
//            <td class="formtable">Sarasota</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">941-926-4777</td>
//            <td class="formtable">-</td>
//            <td class="formtable">
//                <a href = "http://www.covenantlifepc.com" > www.covenantlifepc.com </ a >

//			</ td >

//			< td class="formtable">Suncoast</td>
//            <td class="formtable">Rev.Kenneth A.Aldrich</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=268')" > Covenant Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Palm Bay</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">321-727-2661</td>
//            <td class="formtable">
//                <a href = "mailto:info@covenantpalmbay.org" > info@covenantpalmbay.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.covenantpalmbay.org" > www.covenantpalmbay.org </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Jerry Klemm</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=289')" > Covenant Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Lakeland</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">863-646-9631</td>
//            <td class="formtable">
//                <a href = "mailto:bill@covenantlakeland.org" > bill@covenantlakeland.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.covenantlakeland.org" > www.covenantlakeland.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.David Brian McWilliams</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=294')" > Covenant Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Panama City</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-769-7448</td>
//            <td class="formtable">-</td>
//            <td class="formtable">
//                <a href = "http://www.covenantpca.net" > www.covenantpca.net </ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">Rev.Cory Dean Colravy</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=300')" > Covenant Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Sebring</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">863-385-3234</td>
//            <td class="formtable">
//                <a href = "mailto:cpc@cpcsebring.org" > cpc@cpcsebring.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.cpcsebring.org" > www.cpcsebring.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.Thomas G.Schneider</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=613')" > Covenant Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Oviedo</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">407-432-0426</td>
//            <td class="formtable">
//                <a href = "mailto:info@cpconline.net" > info@cpconline.net</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.cpconline.net" > www.cpconline.net </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Randall R.Greenwald</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5619')" > Cross Community Church of South Florida</a>
//            </td>
//            <td class="formtable">Deerfield Beach</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">954-300-9854</td>
//            <td class="formtable">
//                <a href = "mailto:tommy@thecrosscc.org" > tommy@thecrosscc.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.thecrosscc.org" > www.thecrosscc.org </ a >

//			</ td >

//			< td class="formtable">South Florida</td>
//             <td class="formtable">Rev.Thomas J.Boland</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1653')" > Cross Creek Presbyterian Church</a>
//            </td>
//            <td class="formtable">St.Johns</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">904-287-4334 </td>
//            <td class="formtable">
//                <a href = "mailto:paul@crosscreek.us" > paul@crosscreek.us</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.crosscreek.us" > www.crosscreek.us </ a >

//			</ td >

//			< td class="formtable">North Florida</td>
//             <td class="formtable">Rev.Paul Kalfa</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=620')" > Crossbridge Church Miami</a>
//	            </td>
//            <td class="formtable">Pinecrest</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">305-661-9900</td>
//            <td class="formtable">
//                <a href = "mailto:admin@crossbridgemiami.com" > admin@crossbridgemiami.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.crossbridgemiami.com" > www.crossbridgemiami.com </ a >

//			</ td >

//			< td class="formtable">South Florida</td>
//             <td class="formtable">Rev.Felipe Assis</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1370')" > Cypress Ridge Presbyterian Church</a>
//            </td>
//            <td class="formtable">Winter Haven</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">863-325-9864</td>
//            <td class="formtable">
//                <a href = "mailto:info@cypressridge-pca.org" > info@cypressridge-pca.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.cypressridge-pca.org" > www.cypressridge - pca.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.Thomas G.Luchenbill</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1435')" > Cypress Wood Presbyterian Church</a>
//            </td>
//            <td class="formtable">Naples</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">239-353-8444</td>
//            <td class="formtable">
//                <a href = "mailto:office@cypresswoodpca.com" > office@cypresswoodpca.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.cypresswoodpca.com" > www.cypresswoodpca.com </ a >

//			</ td >

//			< td class="formtable">Suncoast</td>
//            <td class="formtable">Rev.Jonathan Loerop</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=798')" > Dayspring Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Spring Hill</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">352-686-9392</td>
//            <td class="formtable">
//                <a href = "mailto:info@welcometodayspring.com" > info@welcometodayspring.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.welcometodayspring.com" > www.welcometodayspring.com </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Robert Frank Barnes</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=345')" > El Redentor Presbyterian Church</a>
//            </td>
//            <td class="formtable">Miami</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">-</td>
//            <td class="formtable">-</td>
//            <td class="formtable">-</td>
//            <td class="formtable">South Florida</td>
//            <td class="formtable">Rev.Carlos M.Salabarria</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4975')" > El Shaddai of Grace Church</a>
//	            </td>
//            <td class="formtable">Naples</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">239-248-7599</td>
//            <td class="formtable">
//                <a href = "mailto:sdorsainvil@hotmail.com" > sdorsainvil@hotmail.com</a>
//            </td>
//            <td class="formtable">-</td>
//            <td class="formtable">Suncoast</td>
//            <td class="formtable">Rev.Sainvil Dorsainvil</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1626')" > El Shaddai Presbyterian Church</a>
//            </td>
//            <td class="formtable">Miami</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">305-891-8966</td>
//            <td class="formtable">-</td>
//            <td class="formtable">-</td>
//            <td class="formtable">South Florida</td>
//            <td class="formtable">-</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4400')" > El Shalom Haitian Community Church</a>
//	            </td>
//            <td class="formtable">Loxahatchee</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">-</td>
//            <td class="formtable">-</td>
//            <td class="formtable">-</td>
//            <td class="formtable">South Florida</td>
//            <td class="formtable">Rev.Jean Y.Gregoire</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=6086')" > Elohim Evangelical Church</a>
//	            </td>
//            <td class="formtable">Jacksonville</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">904-248-9599</td>
//            <td class="formtable">-</td>
//            <td class="formtable">-</td>
//            <td class="formtable">North Florida</td>
//            <td class="formtable">Rev.Raymond Clotaire</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5350')" > Emanuel Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Boca Raton</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">561-577-2140</td>
//            <td class="formtable">
//                <a href = "mailto:ipemanuel@live.com" > ipemanuel@live.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.ipemanuel.net" > www.ipemanuel.net </ a >

//			</ td >

//			< td class="formtable">Gulfstream</td>
//            <td class="formtable">Rev.Ederson Emerick</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=353')" > Evangelical Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Cape Coral</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">239-549-5556</td>
//            <td class="formtable">
//                <a href = "mailto:admin@epchurch.net" > admin@epchurch.net</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.epchurch.net" > www.epchurch.net </ a >

//			</ td >

//			< td class="formtable">Suncoast</td>
//            <td class="formtable">Rev.Brent Stuart Lauder</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=367')" > Fairfield Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Pensacola</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-455-7245</td>
//            <td class="formtable">
//                <a href = "mailto:fairfieldpca@410.gccoxmail.com" > fairfieldpca@410.gccoxmail.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.fairfieldpca.com" > www.fairfieldpca.com </ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">Rev.Rafael P.De LaGuardia</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=386')" > Faith Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Gainesville</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">352-377-5482</td>
//            <td class="formtable">
//                <a href = "mailto:faith@faithgainesville.org" > faith@faithgainesville.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.faithgainesville.org" > www.faithgainesville.org </ a >

//			</ td >

//			< td class="formtable">North Florida</td>
//             <td class="formtable">Rev.Steve Robert Lammers</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=387')" > Faith Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Sarasota</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">941-955-7074</td>
//            <td class="formtable">
//                <a href = "mailto:info@faithsarasota.org" > info@faithsarasota.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.faithsarasota.org" > www.faithsarasota.org </ a >

//			</ td >

//			< td class="formtable">Suncoast</td>
//            <td class="formtable">Rev.Christopher Knaebel</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=393')" > Faith Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Wauchula</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">863-773-2105</td>
//            <td class="formtable">-</td>
//            <td class="formtable">-</td>
//            <td class="formtable">Southwest Florida</td>
//            <td class="formtable">-</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=420')" > First Church West</a>
//	            </td>
//            <td class="formtable">Tamarac</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">954-726-2301</td>
//            <td class="formtable">
//                <a href = "mailto:normwise@bellsouth.net" > normwise@bellsouth.net</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://firstchurchwest.org" > firstchurchwest.org </ a >

//			</ td >

//			< td class="formtable">South Florida</td>
//             <td class="formtable">Rev.Norman R.Wise</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5966')" > First Korean Presbyterian Church of Orlando</a>
//            </td>
//            <td class="formtable">Orlando</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">407-295-1199</td>
//            <td class="formtable">-</td>
//            <td class="formtable">
//                <a href = "http://www.orlandofirst.org" > www.orlandofirst.org </ a >

//			</ td >

//			< td class="formtable">Korean Southeastern</td>
//             <td class="formtable">Rev.Cuseong Paek</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=451')" > First Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Panama City</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-785-7423</td>
//            <td class="formtable">
//                <a href = "mailto:fpcpc@fpcpc.comcastbiz.net" > fpcpc@fpcpc.comcastbiz.net</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.firstprespc.org" > www.firstprespc.org </ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">Rev.Ron E.Brown</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=452')" > First Presbyterian Church</a>
//	            </td>
//            <td class="formtable">North Port</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">941-421-8163</td>
//            <td class="formtable">
//                <a href = "mailto:abrev@comcast.net" > abrev@comcast.net</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.fpcnorthportfl.net" > www.fpcnorthportfl.net </ a >

//			</ td >

//			< td class="formtable">Suncoast</td>
//            <td class="formtable">Rev.Arnold Allen Brevick</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1592')" > First Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Niceville</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-678-2521</td>
//            <td class="formtable">
//                <a href = "mailto:office@fpcniceville.org" > office@fpcniceville.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.fpcniceville.org" > www.fpcniceville.org </ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">Rev.Joseph C.Grider</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=418')" > First Presbyterian Church of Coral Springs</a>
//            </td>
//            <td class="formtable">Coral Springs</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">954-752-3030</td>
//            <td class="formtable">
//                <a href = "mailto:info@fpccoralsprings.org" > info@fpccoralsprings.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.fpccoralsprings.org" > www.fpccoralsprings.org </ a >

//			</ td >

//			< td class="formtable">South Florida</td>
//             <td class="formtable">Rev.Andrew J.DiNardo</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=651')" > FWB International Community Church Mission</a>
//	            </td>
//            <td class="formtable">Ft.Walton Beach</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-244-0691</td>
//            <td class="formtable">-</td>
//            <td class="formtable">-</td>
//            <td class="formtable">Korean Southeastern</td>
//            <td class="formtable">Rev.Joshua Suk Ho Jea</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5962')" > Gainesville Open Kingdom Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Gainesville</td>
//            <td class="formtable">Fl</td>
//            <td class="formtable">-</td>
//            <td class="formtable">-</td>
//            <td class="formtable">
//                <a href = "http://www.gainesvilleokpca.com" > www.gainesvilleokpca.com </ a >

//			</ td >

//			< td class="formtable">Korean Southeastern</td>
//             <td class="formtable">-</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1292')" > Good News Church</a>
//	            </td>
//            <td class="formtable">St.Augustine</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">904-819-0064</td>
//            <td class="formtable">
//                <a href = "mailto:goodnews@gnpc.org" > goodnews@gnpc.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.gnpc.org" > www.gnpc.org </ a >

//			</ td >

//			< td class="formtable">North Florida</td>
//             <td class="formtable">Rev.Smiley Sturgis</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5568')" > Good News World Golf Village</a>
//	            </td>
//            <td class="formtable">St.Augustine</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">904-819-0064</td>
//            <td class="formtable">-</td>
//            <td class="formtable">
//                <a href = "http://http:ngpc.org" > http:ngpc.org</a>
//            </td>
//            <td class="formtable">North Florida</td>
//            <td class="formtable">-</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1400')" > Good Shepherd Presbyterian Church</a>
//            </td>
//            <td class="formtable">Ocala</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">352-291-9199</td>
//            <td class="formtable">-</td>
//            <td class="formtable">
//                <a href = "http://www.gspcocala.com" > www.gspcocala.com </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Ted R.Strawbridge</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4073')" > Grace Community Church</a>
//	            </td>
//            <td class="formtable">Yulee</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">904-491-0363</td>
//            <td class="formtable">
//                <a href = "mailto:office@gracenassau.com" > office@gracenassau.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.gracenassau.com" > www.gracenassau.com </ a >

//			</ td >

//			< td class="formtable">North Florida</td>
//             <td class="formtable">Rev.David Bradsher</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=222')" > Grace Community Church</a>
//	            </td>
//            <td class="formtable">Palm Harbor</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">727-789-2124</td>
//            <td class="formtable">
//                <a href = "mailto:office@gccpalmharbor.org" > office@gccpalmharbor.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.gccpalmharbor.org" > www.gccpalmharbor.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.Brent Allen Bergman</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5709')" > Grace Covenant Presbyterian Church</a>
//            </td>
//            <td class="formtable">Hilliard</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">904-845-7863</td>
//            <td class="formtable">
//                <a href = "mailto:info@gc-pca.org" > info@gc-pca.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.gc-pca.org" > www.gc - pca.org </ a >

//			</ td >

//			< td class="formtable">North Florida</td>
//             <td class="formtable">Rev.Stephen C.Jennings</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1472')" > Grace Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Palm Coast</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">386-437-8363</td>
//            <td class="formtable">
//                <a href = "mailto:mpearson26@cfl.rr.com" > mpearson26@cfl.rr.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.palmcoastgracepca.org" > www.palmcoastgracepca.org </ a >

//			</ td >

//			< td class="formtable">North Florida</td>
//             <td class="formtable">Rev.Mark Pearson</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=528')" > Grace Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Madison</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-973-2692</td>
//            <td class="formtable">
//                <a href = "mailto:1pastorgary@comcast.net" > 1pastorgary @comcast.net</a>
//	            </td>
//            <td class="formtable">
//                <a href = "http://www.gracemadisonfl.org" > www.gracemadisonfl.org </ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">Dr.Gary R.Cox</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=533')" > Grace Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Stuart</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">772-692-1995</td>
//            <td class="formtable">
//                <a href = "mailto:info@gracestuart.com" > info@gracestuart.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.gracestuart.com" > www.gracestuart.com </ a >

//			</ td >

//			< td class="formtable">Gulfstream</td>
//            <td class="formtable">Rev.Bernie van Eyk</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=537')" > Grace Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Ocala</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">352-629-1537</td>
//            <td class="formtable">
//                <a href = "mailto:grace@graceocala.com" > grace@graceocala.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.graceocala.com" > www.graceocala.com </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Carl D.Brannan, Jr.</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1217')" > Grace Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Lake Suzy</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">941-743-7971</td>
//            <td class="formtable">
//                <a href = "mailto:pastordave@gracelakesuzy.com" > pastordave@gracelakesuzy.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.gracelakesuzy.com" > www.gracelakesuzy.com </ a >

//			</ td >

//			< td class="formtable">Suncoast</td>
//            <td class="formtable">Rev.David L.Stewart</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5475')" > Grace Redeemer PCA</a>
//	            </td>
//            <td class="formtable">Crestview</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-612-0398</td>
//            <td class="formtable">
//                <a href = "mailto:graceredeemer.david@gmail.com" > graceredeemer.david@gmail.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.graceredeemerpca.org" > www.graceredeemerpca.org </ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">Rev.David S.Young</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=566')" > Granada Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Coral Gables</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">305-444-8435</td>
//            <td class="formtable">
//                <a href = "mailto:granada@granadapca.org" > granada@granadapca.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.granadapca.org" > www.granadapca.org </ a >

//			</ td >

//			< td class="formtable">South Florida</td>
//             <td class="formtable">Rev.D.Worth Carson</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=6030')" > Gulf Coast Presbyterian Mission</a>
//            </td>
//            <td class="formtable">Ft.Myers</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">239-877-3776</td>
//            <td class="formtable">
//                <a href = "mailto:doug@gulfcoastpres.com" > doug@gulfcoastpres.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.gulfcoastpres.com" > www.gulfcoastpres.com </ a >

//			</ td >

//			< td class="formtable">Suncoast</td>
//            <td class="formtable">Rev.Douglas D.Warren</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1058')" > Hammock Street Church</a>
//	            </td>
//            <td class="formtable">Boca Raton</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">561-483-0460</td>
//            <td class="formtable">
//                <a href = "mailto:info@hammockstreetchurch.com" > info@hammockstreetchurch.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.hammockstreetchurch.com" > www.hammockstreetchurch.com </ a >

//			</ td >

//			< td class="formtable">Gulfstream</td>
//            <td class="formtable">Rev.Russell Silverglate</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5739')" > Harbor Community Mission</a>
//	            </td>
//            <td class="formtable">Bradenton</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">941-727-4047</td>
//            <td class="formtable">
//                <a href = "mailto:office@harborcommunitychurch.org" > office@harborcommunitychurch.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.harborcommunitychurch.org" > www.harborcommunitychurch.org </ a >

//			</ td >

//			< td class="formtable">Suncoast</td>
//            <td class="formtable">Rev.Geoffrey C.Henderson</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4052')" > Holy Trinity Presbyterian Church</a>
//            </td>
//            <td class="formtable">Tampa</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">813-259-3500</td>
//            <td class="formtable">
//                <a href = "mailto:office@holytrinitypca.org" > office@holytrinitypca.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.holytrinitypca.org" > www.holytrinitypca.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.Stephen J.Casselli</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=619')" > Immanuel Presbyterian Church</a>
//	            </td>
//            <td class="formtable">DeLand</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">386-738-1811</td>
//            <td class="formtable">
//                <a href = "mailto:office@immanuelpca.com" > office@immanuelpca.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.immanuelpca.com" > www.immanuelpca.com </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Michael R.Francis</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=634')" > Kendall Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Miami</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">305-271-5262</td>
//            <td class="formtable">
//                <a href = "mailto:kpcpca@bellsouth.net" > kpcpca@bellsouth.net</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.kendallpres.org" > www.kendallpres.org </ a >

//			</ td >

//			< td class="formtable">South Florida</td>
//             <td class="formtable">Rev.Kent L.Keller</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=635')" > Key Biscayne Presbyterian Church</a>
//            </td>
//            <td class="formtable">Key Biscayne</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">305-361-2058</td>
//            <td class="formtable">
//                <a href = "mailto:office@kbpc.org" > office@kbpc.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.kbpc.org" > www.kbpc.org </ a >

//			</ td >

//			< td class="formtable">South Florida</td>
//             <td class="formtable">Rev.David L.Moran</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5963')" > Korean Community Church of Ft.Myers</a>
//	            </td>
//            <td class="formtable">North Ft.Myers</td>
//            <td class="formtable">Fl</td>
//            <td class="formtable">-</td>
//            <td class="formtable">-</td>
//            <td class="formtable">
//                <a href = "http://www.kpcfortmyers.org" > www.kpcfortmyers.org </ a >

//			</ td >

//			< td class="formtable">Korean Southeastern</td>
//             <td class="formtable">Rev.Noh Moon Park</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4597')" > Korean Cornerstone Presbyterian Church of Jacksonville</a>
//            </td>
//            <td class="formtable">Jacksonville</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">904-260-3670 </td>
//            <td class="formtable">
//                <a href = "mailto:hwangbpc@yahoo.com" > hwangbpc@yahoo.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.betheljax.org" > www.betheljax.org </ a >

//			</ td >

//			< td class="formtable">Korean Southeastern</td>
//             <td class="formtable">Rev.Youngsu Jeong</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5781')" > Korean Open Church of Tampa Bay</a>
//            </td>
//            <td class="formtable">Tampa</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">813-362-4516</td>
//            <td class="formtable">-</td>
//            <td class="formtable">-</td>
//            <td class="formtable">Korean Southeastern</td>
//            <td class="formtable">Rev.Myung Shik Ju</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4787')" > Lake Baldwin Church</a>
//	            </td>
//            <td class="formtable">Orlando</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">-</td>
//            <td class="formtable">
//                <a href = "mailto:hello@lakebaldwinchurch.com" > hello@lakebaldwinchurch.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.lakebaldwinchurch.com" > www.lakebaldwinchurch.com </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Michael Tilley</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=672')" > Lake Osborne Presbyterian Church</a>
//            </td>
//            <td class="formtable">Lake Worth</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">561-582-5686</td>
//            <td class="formtable">
//                <a href = "mailto:info@lakeosborne.org" > info@lakeosborne.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.lakeosborne.org" > www.lakeosborne.org </ a >

//			</ td >

//			< td class="formtable">Gulfstream</td>
//            <td class="formtable">Rev.V.Omar Ortiz</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=711')" > Marco Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Marco Island</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">239-394-8186</td>
//            <td class="formtable">
//                <a href = "mailto:office@marcochurch.com" > office@marcochurch.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.marcochurch.com" > www.marcochurch.com </ a >

//			</ td >

//			< td class="formtable">Suncoast</td>
//            <td class="formtable">Rev.Steven Kendall Schoof</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=718')" > McIlwain Memorial Presbyterian Church</a>
//            </td>
//            <td class="formtable">Pensacola</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-438-5449</td>
//            <td class="formtable">
//                <a href = "mailto:info@mcilwain.org" > info@mcilwain.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.mcilwain.org" > www.mcilwain.org </ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">Rev.Robert B.Looper</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5782')" > Melbourne Open Kingdom</a>
//	            </td>
//            <td class="formtable">Melbourne</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">951-870-0113</td>
//            <td class="formtable">
//                <a href = "mailto:openkingdom@yahoo.com" > openkingdom@yahoo.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://openkingdom.org" > openkingdom.org </ a >

//			</ td >

//			< td class="formtable">Korean Southeastern</td>
//             <td class="formtable">Rev.Paul Jay Cha</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4547')" > Miami River Mission Church</a>
//            </td>
//            <td class="formtable">Miami</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">-</td>
//            <td class="formtable">-</td>
//            <td class="formtable">-</td>
//            <td class="formtable">South Florida</td>
//            <td class="formtable">Rev.Joshua Lopez</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4196')" > Nature Coast Community Church</a>
//            </td>
//            <td class="formtable">Homosassa</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">352-628-6222</td>
//            <td class="formtable">
//                <a href = "mailto:office@n3c.org" > office@n3c.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.n3c.org" > www.n3c.org </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Brad Lee Bresson</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5824')" > New City Church - The Gardens</a>
//	            </td>
//            <td class="formtable">Palm Beach Gardens</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">561-389-4382</td>
//            <td class="formtable">
//                <a href = "mailto:pastor@newcitychurchpbg.org" > pastor@newcitychurchpbg.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.newcitychurchpbg.org" > www.newcitychurchpbg.org </ a >

//			</ td >

//			< td class="formtable">Gulfstream</td>
//            <td class="formtable">Rev.Matthew Edward Wilson</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5950')" > New City Fellowship Church</a>
//            </td>
//            <td class="formtable">Hollywood</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">954-609-6922</td>
//            <td class="formtable">
//                <a href = "mailto:newcitysfl@gmail.com" > newcitysfl@gmail.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.hhchurchplant.com" > www.hhchurchplant.com </ a >

//			</ td >

//			< td class="formtable">South Florida</td>
//             <td class="formtable">Rev.John Houmes</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1161')" > New Hope Presbyterian Church</a>
//            </td>
//            <td class="formtable">Eustis</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">352-483-3833</td>
//            <td class="formtable">
//                <a href = "mailto:office@newhopepca.com" > office@newhopepca.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.newhopepca.com" > www.newhopepca.com </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Richard L.Burguet</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1682')" > New Life Church</a>
//	            </td>
//            <td class="formtable">Rockledge</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">321-631-2836</td>
//            <td class="formtable">
//                <a href = "mailto:info@livethenewlife.com" > info@livethenewlife.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.livethenewlife.com" > www.livethenewlife.com </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Brent S.Drake</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1594')" > New Life Presbyterian Church</a>
//            </td>
//            <td class="formtable">Minneola</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">352-241-8101</td>
//            <td class="formtable">
//                <a href = "mailto:contact@newlifeminneola.com" > contact@newlifeminneola.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.newlifeminneola.com" > www.newlifeminneola.com </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.John R.Bopp</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=778')" > New Philadelphia Presbyterian Church</a>
//            </td>
//            <td class="formtable">Quincy</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-566-7015</td>
//            <td class="formtable">-</td>
//            <td class="formtable">-</td>
//            <td class="formtable">Gulf Coast</td>
//            <td class="formtable">Rev.Jerome Roger Dodson, III</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5468')" > NewCity Orlando</a>
//            </td>
//            <td class="formtable">Orlando</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">407-872-0883</td>
//            <td class="formtable">
//                <a href = "mailto:newcity@newcityorlando.com" > newcity@newcityorlando.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.newcityorlando.com" > www.newcityorlando.com </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Tedrick Sinn</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4768')" > North Ft.Myers Presbyterian Church</a>
//            </td>
//            <td class="formtable">North Ft.Myers</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">239-543-1323</td>
//            <td class="formtable">
//                <a href = "mailto:danncecil@embarqmail.com" > danncecil@embarqmail.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.nfmpresbyterian.com" > www.nfmpresbyterian.com </ a >

//			</ td >

//			< td class="formtable">Suncoast</td>
//            <td class="formtable">Rev.Dann Cecil</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1466')" > Northside Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Melbourne</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">321-255-0701</td>
//            <td class="formtable">
//                <a href = "mailto:northsidepresbyt@bellsouth.net" > northsidepresbyt@bellsouth.net</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.northsidepca.org" > www.northsidepca.org </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Jeffrey W.Godwin</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5565')" > Oak River Presbyterian Church</a>
//            </td>
//            <td class="formtable">Bonita Springs</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">239-293-2045</td>
//            <td class="formtable">
//                <a href = "mailto:matt@oakriver.org" > matt@oakriver.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.oakriver.org" > www.oakriver.org </ a >

//			</ td >

//			< td class="formtable">Suncoast</td>
//            <td class="formtable">Rev.Matthew Loveall</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4165')" > Ocala Korean Presbyterian Church</a>
//            </td>
//            <td class="formtable">Ocala</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">352-867-0191</td>
//            <td class="formtable">
//                <a href = "mailto:okpc21@gmail.com" > okpc21@gmail.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.ocalakoreanchurch.org" > www.ocalakoreanchurch.org </ a >

//			</ td >

//			< td class="formtable">Korean Southeastern</td>
//             <td class="formtable">Rev.Sam Kim</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=805')" > Old Cutler Presbyterian Church</a>
//            </td>
//            <td class="formtable">Palmetto Bay</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">305-238-8121</td>
//            <td class="formtable">-</td>
//            <td class="formtable">
//                <a href = "http://www.ocpc.org" > www.ocpc.org </ a >

//			</ td >

//			< td class="formtable">South Florida</td>
//             <td class="formtable">Rev.Michael A.Campbell</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=813')" > Orangewood Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Maitland</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">407-539-1500</td>
//            <td class="formtable">
//                <a href = "mailto:info@orangewood.org" > info@orangewood.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.orangewood.org" > www.orangewood.org </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Jeffrey Jakes</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5595')" > Orlando Chinese Evangelical Christian Church</a>
//	            </td>
//            <td class="formtable">Casselberry</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">407-331-1477 </td>
//            <td class="formtable">
//                <a href = "mailto:servants@ocecc.org" > servants@ocecc.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.ocecc.org" > www.ocecc.org </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Biao Chen</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1671')" > Orlando Korean Presbyterian Church in America</a>
//            </td>
//            <td class="formtable">Orlando</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">321-251-5252</td>
//            <td class="formtable">
//                <a href = "mailto:jaelee4christ@hotmail.com" > jaelee4christ@hotmail.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.okpca.com" > www.okpca.com </ a >

//			</ td >

//			< td class="formtable">Korean Southeastern</td>
//             <td class="formtable">Rev.Jae Ryong Lee</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1253')" > Ortega Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Jacksonville</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">904-389-4043</td>
//            <td class="formtable">
//                <a href = "mailto:office@ortegapres.org" > office@ortegapres.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.ortegapres.org" > www.ortegapres.org </ a >

//			</ td >

//			< td class="formtable">North Florida</td>
//             <td class="formtable">Rev.David L.Burke</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1297')" > Panama City Korean Church</a>
//            </td>
//            <td class="formtable">Panama City</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-769-8836</td>
//            <td class="formtable">
//                <a href = "mailto:iamwatchingmovie@gmail.com" > iamwatchingmovie@gmail.com</a>
//            </td>
//            <td class="formtable">-</td>
//            <td class="formtable">Korean Southeastern</td>
//            <td class="formtable">Rev.Zadok Hong</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=918')" > Pine Ridge Presbyterian Church</a>
//            </td>
//            <td class="formtable">Orlando</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">407-293-7298</td>
//            <td class="formtable">
//                <a href = "mailto:pineridgepca@gmail.com" > pineridgepca@gmail.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.pineridgepca.org" > www.pineridgepca.org </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.William J.Colclasure</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=835')" > Pinelands Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Miami</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">305-235-1142</td>
//            <td class="formtable">
//                <a href = "mailto:info@pinelandspca.org" > info@pinelandspca.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.pinelandspca.org" > www.pinelandspca.org </ a >

//			</ td >

//			< td class="formtable">South Florida</td>
//             <td class="formtable">Dr.Nathan T.Parker</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=836')" > Pinewood Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Jacksonville</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">904-272-7177</td>
//            <td class="formtable">-</td>
//            <td class="formtable">
//                <a href = "http://www.pinewoodpca.org" > www.pinewoodpca.org </ a >

//			</ td >

//			< td class="formtable">North Florida</td>
//             <td class="formtable">Rev.James D.Funyak</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=837')" > Pinewoods Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Pensacola</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-968-9342</td>
//            <td class="formtable">
//                <a href = "mailto:info@pinewoodschurch.org" > info@pinewoodschurch.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.pinewoodschurch.org" > www.pinewoodschurch.org </ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">Rev.Joel Treick</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1179')" > Ponte Vedra Presbyterian Church</a>
//            </td>
//            <td class="formtable">Ponte Vedra Beach</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">904-285-8225</td>
//            <td class="formtable">
//                <a href = "mailto:dpatterson@pvpc.com" > dpatterson@pvpc.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.pvpc.com" > www.pvpc.com </ a >

//			</ td >

//			< td class="formtable">North Florida</td>
//             <td class="formtable">Rev.Richard Cooper</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4548')" > Prince of Peace Mission Church</a>
//	            </td>
//            <td class="formtable">Weston</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">954-865-1673</td>
//            <td class="formtable">
//                <a href = "mailto:pablotoledo@comcast.net" > pablotoledo@comcast.net</a>
//            </td>
//            <td class="formtable">-</td>
//            <td class="formtable">South Florida</td>
//            <td class="formtable">-</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=902')" > Redeemer Community Church</a>
//	            </td>
//            <td class="formtable">Spring Hill</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">727-842-5278</td>
//            <td class="formtable">
//                <a href = "mailto:pastor.bg@gmail.com" > pastor.bg@gmail.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.redeemernpr.org" > www.redeemernpr.org </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.William Gunter</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4669')" > Redeemer Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Inverness</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">352-726-0077</td>
//            <td class="formtable">
//                <a href = "mailto:info@tryrpc.com" > info@tryrpc.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.tryrpc.com" > www.tryrpc.com </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Ryan S.Jeffes</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4759')" > Redeemer Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Lakeland</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">863-660-5448</td>
//            <td class="formtable">
//                <a href = "mailto:redeemerlakeland@yahoo.com" > redeemerlakeland@yahoo.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.redeemerlakeland.org" > www.redeemerlakeland.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.David Lee Martin</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4943')" > Redeemer Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Titusville</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">321-264-0035</td>
//            <td class="formtable">
//                <a href = "mailto:office@myredeemer.cc" > office@myredeemer.cc</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.myredeemer.cc" > www.myredeemer.cc </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Gary Ginn</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4078')" > Redeemer Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Riverview</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">813-741-1776</td>
//            <td class="formtable">
//                <a href = "mailto:office@redeemerriverview.org" > office@redeemerriverview.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.redeemerriverview.org" > www.redeemerriverview.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.Craig A.Swartz</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4378')" > Redeemer Presbyterian of North Miami</a>
//	            </td>
//            <td class="formtable">North Miami</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">305-945-4283</td>
//            <td class="formtable">-</td>
//            <td class="formtable">-</td>
//            <td class="formtable">South Florida</td>
//            <td class="formtable">Rev.Gueillant Dorcinvil</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5309')" > Redeemer Winter Haven</a>
//	            </td>
//            <td class="formtable">Winter Haven</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">863-298-9849</td>
//            <td class="formtable">
//                <a href = "mailto:info@redeemerwinterhaven.org" > info@redeemerwinterhaven.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.redeemerwinterhaven.org" > www.redeemerwinterhaven.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.Drew Bennett</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=884')" > Redlands Community Church</a>
//	            </td>
//            <td class="formtable">Homestead</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">305-258-1132</td>
//            <td class="formtable">
//                <a href = "mailto:sue@redlandscommunitychurch.org" > sue@redlandscommunitychurch.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.redlandscommunitychurch.org" > www.redlandscommunitychurch.org </ a >

//			</ td >

//			< td class="formtable">South Florida</td>
//             <td class="formtable">-</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=96')" > Rio Vista Community Church</a>
//            </td>
//            <td class="formtable">Ft.Lauderdale</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">954-522-2518</td>
//            <td class="formtable">
//                <a href = "mailto:info@riovistachurch.com" > info@riovistachurch.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.riovistachurch.com" > www.riovistachurch.com </ a >

//			</ td >

//			< td class="formtable">South Florida</td>
//             <td class="formtable">Rev.Thomas John Hendrikse</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1303')" > River Oaks Presbyterian Church</a>
//            </td>
//            <td class="formtable">Lake Mary</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">407-330-9103</td>
//            <td class="formtable">
//                <a href = "mailto:riveroaks@riveroakschurch.com" > riveroaks@riveroakschurch.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.riveroakschurch.com" > www.riveroakschurch.com </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.David Camera</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4261')" > River of Hope Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Miami</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">786-255-5252</td>
//            <td class="formtable">-</td>
//            <td class="formtable">
//                <a href = "http://www.myriverofhope.org" > www.myriverofhope.org </ a >

//			</ td >

//			< td class="formtable">South Florida</td>
//             <td class="formtable">Rev.Matthew A.Dubocq</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1537')" > River of Life Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Orlando</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">407-376-1053</td>
//            <td class="formtable">-</td>
//            <td class="formtable">-</td>
//            <td class="formtable">Central Florida</td>
//            <td class="formtable">Rev.Charles B.Holliday, III</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=914')" > Safe Harbor Presbyterian Church</a>
//            </td>
//            <td class="formtable">Destin</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-837-2133</td>
//            <td class="formtable">
//                <a href = "mailto:safeharborpca@gmail.com" > safeharborpca@gmail.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.safeharborpcadestin.org" > www.safeharborpcadestin.org </ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">Rev.James Calderazzo</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4380')" > Sand Harbor Presbyterian Church</a>
//            </td>
//            <td class="formtable">Jupiter</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">561-316-3862</td>
//            <td class="formtable">
//                <a href = "mailto:sandharborpresbyterian@gmail.com" > sandharborpresbyterian@gmail.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.sandharborpca.org" > www.sandharborpca.org </ a >

//			</ td >

//			< td class="formtable">Gulfstream</td>
//            <td class="formtable">Rev.Andrew L.Jacobson</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=924')" > Seacrest Boulevard Presbyterian Church</a>
//            </td>
//            <td class="formtable">Delray Beach</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">561-276-5533</td>
//            <td class="formtable">
//                <a href = "mailto:spc@seacrestchurch.com" > spc@seacrestchurch.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.seacrestchurch.com" > www.seacrestchurch.com </ a >

//			</ td >

//			< td class="formtable">Gulfstream</td>
//            <td class="formtable">Rev.Randolph H.Patterson</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=928')" > Seminole Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Tampa</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">813-774-3881</td>
//            <td class="formtable">
//                <a href = "mailto:church@seminolepca.org" > church@seminolepca.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.seminolepca.org" > www.seminolepca.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.John K.Keen</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=930')" > Seven Rivers Presbyterian Church</a>
//            </td>
//            <td class="formtable">Lecanto</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">352-746-6200</td>
//            <td class="formtable">
//                <a href = "mailto:srpc@sevenrivers.org" > srpc@sevenrivers.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.sevenrivers.org" > www.sevenrivers.org </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Raymond A.Cortese</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5895')" > Sojourner Presbyterian Mission</a>
//	            </td>
//            <td class="formtable">Tampa</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">813-362-3573</td>
//            <td class="formtable">
//                <a href = "mailto:stevenlight@sojournerpca.org" > stevenlight@sojournerpca.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.sojournerpca.org" > www.sojournerpca.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.John Steven Light, Jr.</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=953')" > Spanish River Presbyterian Church</a>
//            </td>
//            <td class="formtable">Boca Raton</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">561-994-5000</td>
//            <td class="formtable">
//                <a href = "mailto:hello@spanishriver.com" > hello@spanishriver.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.spanishriver.com" > www.spanishriver.com </ a >

//			</ td >

//			< td class="formtable">Gulfstream</td>
//            <td class="formtable">Dr.Tommy Kiedis</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1544')" > Springs Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Dunnellon</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">352-489-8992</td>
//            <td class="formtable">
//                <a href = "mailto:spc@springspca.org" > spc@springspca.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.springspca.org" > www.springspca.org </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Dr.R.Keeth Staton</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=957')" > Spruce Creek Presbyterian Church</a>
//            </td>
//            <td class="formtable">Port Orange</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">386-761-2902</td>
//            <td class="formtable">
//                <a href = "mailto:scpca@cfl.rr.com" > scpca@cfl.rr.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.sprucecreekpca.org" > www.sprucecreekpca.org </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Jeffrey R.Birch</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=959')" > St.Andrews Presbyterian Church</a>
//               </td>
//            <td class="formtable">Hollywood</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">954-989-2655</td>
//            <td class="formtable">
//                <a href = "mailto:mail@standrewspca.com" > mail@standrewspca.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.standrewspca.com" > www.standrewspca.com </ a >

//			</ td >

//			< td class="formtable">South Florida</td>
//             <td class="formtable">Rev.Theodore Joseph Campo</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1329')" > St.Paul's Presbyterian Church</a>
//            </td>
//            <td class="formtable">Orlando</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">407-647-7774</td>
//            <td class="formtable">
//                <a href = "mailto:staff@stpaulpca.org" > staff@stpaulpca.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.stpaulpca.org" > www.stpaulpca.org </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Frank Cavalli</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4365')" > St.Petersburg Presbyterian Church</a>
//               </td>
//            <td class="formtable">St.Petersburg</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">727-329-6346</td>
//            <td class="formtable">
//                <a href = "mailto:sppcinfo@stpetepca.org" > sppcinfo@stpetepca.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.stpetepca.org" > www.stpetepca.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.David L.Harding</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5896')" > Strong Tower Mission</a>
//	            </td>
//            <td class="formtable">Lakeland</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">863-940-9777</td>
//            <td class="formtable">
//                <a href = "mailto:lauren@strongtower.org" > lauren@strongtower.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.strongtower.org" > www.strongtower.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.Benjamin James Turner</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=975')" > Tampa Bay Presbyterian Church</a>
//            </td>
//            <td class="formtable">Tampa</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">813-973-2484</td>
//            <td class="formtable">
//                <a href = "mailto:office@tampabaypresbyterian.org" > office@tampabaypresbyterian.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.tampabaypresbyterian.org" > www.tampabaypresbyterian.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.Freddy Fritz</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5513')" > The Avenue Church</a>
//	            </td>
//            <td class="formtable">Delray Beach</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">561-927-4000</td>
//            <td class="formtable">
//                <a href = "mailto:info@theavechurch.com" > info@theavechurch.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.theavechurch.com" > www.theavechurch.com </ a >

//			</ td >

//			< td class="formtable">Gulfstream</td>
//            <td class="formtable">Rev.Casey Cleveland</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1652')" > Treasure Coast Presbyterian Church</a>
//            </td>
//            <td class="formtable">Stuart</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">772-223-8718</td>
//            <td class="formtable">
//                <a href = "mailto:admin@treasurecoastpca.org" > admin@treasurecoastpca.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.treasurecoastpca.org" > www.treasurecoastpca.org </ a >

//			</ td >

//			< td class="formtable">Gulfstream</td>
//            <td class="formtable">-</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1662')" > Trinity Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Lakeland</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">863-603-7777</td>
//            <td class="formtable">
//                <a href = "mailto:trinity@trinitylakeland.org" > trinity@trinitylakeland.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.trinitylakeland.org" > www.trinitylakeland.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.Timothy W.Rice</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=5359')" > Truth Point Church</a>
//	            </td>
//            <td class="formtable">West Palm Beach</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">561-891-9973</td>
//            <td class="formtable">
//                <a href = "mailto:pastorj@truthpoint.org" > pastorj@truthpoint.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.truthpoint.org" > www.truthpoint.org </ a >

//			</ td >

//			< td class="formtable">Gulfstream</td>
//            <td class="formtable">Rev.Jeremy McKeen</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=281')" > University Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Orlando</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">407-384-3300</td>
//            <td class="formtable">
//                <a href = "mailto:upcoffice@upc-orlando.com" > upcoffice@upc-orlando.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.upc-orlando.com" > www.upc - orlando.com </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Matthew Ryman</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=6087')" > Vintage Grace Church</a>
//	            </td>
//            <td class="formtable">Orange Park</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">-</td>
//            <td class="formtable">
//                <a href = "mailto:russell@vintagegrace.church" > russell@vintagegrace.church</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://vintagegrace.church" > vintagegrace.church </ a >

//			</ td >

//			< td class="formtable">North Florida</td>
//             <td class="formtable">Rev.Russell Jeffares</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1051')" > Warrington Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Pensacola</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-455-0301</td>
//            <td class="formtable">
//                <a href = "mailto:office@wpca.net" > office@wpca.net</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.wpca.net" > www.wpca.net </ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">Rev.Philip Futoran</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1056')" > Wellington Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Wellington</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">561-793-1007</td>
//            <td class="formtable">
//                <a href = "mailto:churchoffice@wpcfl.com" > churchoffice@wpcfl.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.wpcfl.com" > www.wpcfl.com </ a >

//			</ td >

//			< td class="formtable">Gulfstream</td>
//            <td class="formtable">-</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1070')" > Westminster Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Jacksonville</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">904-737-5133</td>
//            <td class="formtable">
//                <a href = "mailto:wpcajax@gmail.com" > wpcajax@gmail.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.wpcajax.us" > www.wpcajax.us </ a >

//			</ td >

//			< td class="formtable">North Florida</td>
//             <td class="formtable">Rev.Stephen C.Jennings</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1072')" > Westminster Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Ft.Myers</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">239-481-2125</td>
//            <td class="formtable">
//                <a href = "mailto:office@wpcfortmyers.org" > office@wpcfortmyers.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://wpcfortmyers.org" > wpcfortmyers.org </ a >

//			</ td >

//			< td class="formtable">Suncoast</td>
//            <td class="formtable">Rev.Robert F.Brunson</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1076')" > Westminster Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Brandon</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">813-689-6541</td>
//            <td class="formtable">
//                <a href = "mailto:office@wpcbrandon.org" > office@wpcbrandon.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.wpcbrandon.org" > www.wpcbrandon.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.William Wesley Holland, Jr.</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1084')" > Westminster Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Milton</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-623-3731</td>
//            <td class="formtable">
//                <a href = "mailto:pastor@wpcmilton.org" > pastor@wpcmilton.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.wpcmilton.org" > www.wpcmilton.org </ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">-</td>

//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1104')" > Westminster Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Ft.Walton Beach</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-862-8825</td>
//            <td class="formtable">
//                <a href = "mailto:wpcpca@embarqmail.com" > wpcpca@embarqmail.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.wpc-pca.com" > www.wpc - pca.com </ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">Rev.William H.Tyson</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1106')" > Westminster Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Tallahassee</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-894-4233</td>
//            <td class="formtable">
//                <a href = "mailto:jgcraft@juno.com" > jgcraft@juno.com</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.wpctlh.org" > www.wpctlh.org </ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">Rev.James G.Craft</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=4852')" > Westtown Church</a>
//            </td>
//            <td class="formtable">Tampa</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">813-855-2747</td>
//            <td class="formtable">
//                <a href = "mailto:office@westtownchurch.org" > office@westtownchurch.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.westtownchurch.org" > www.westtownchurch.org </ a >

//			</ td >

//			< td class="formtable">Southwest Florida</td>
//             <td class="formtable">Rev.Frank Taylor</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1122')" > Wildwood Presbyterian Church</a>
//	            </td>
//            <td class="formtable">Tallahassee</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">850-894-1400</td>
//            <td class="formtable">
//                <a href = "mailto:info@wildwoodchurchonline.org" > info@wildwoodchurchonline.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.wildwoodchurchonline.org" > www.wildwoodchurchonline.org </ a >

//			</ td >

//			< td class="formtable">Gulf Coast</td>
//             <td class="formtable">Rev.Robert S.Evans</td>
 
//        </tr>
//        <tr>
//            <td>&nbsp;</td>
//            <td class="formtableleft">
//                <a href = "javascript:makeWin('churchinfo.cfm?OrgID=1123')" > Willow Creek Church</a>
//	            </td>
//            <td class="formtable">Winter Springs</td>
//            <td class="formtable">FL</td>
//            <td class="formtable">407-699-8211</td>
//            <td class="formtable">
//                <a href = "mailto:info@willowcreekchurch.org" > info@willowcreekchurch.org</a>
//            </td>
//            <td class="formtable">
//                <a href = "http://www.willowcreekchurch.org" > www.willowcreekchurch.org </ a >

//			</ td >

//			< td class="formtable">Central Florida</td>
//             <td class="formtable">Rev.Kevin Labby</td>
 
//        </tr>



//    </table>

//</form>
//<table width = "900" border= "0" cellspacing= "0" cellpadding= "0" >
 
//	 < tr >
 
//		 < td > &nbsp;</td>
//        <td style = "font-size:9pt" >

//			< a href="http://www.pcaac.org">
//                <u>Return to PCA Home Page</u>
//            </a>
//        </td>

//    </table>


//</body>
//undefined</html>
