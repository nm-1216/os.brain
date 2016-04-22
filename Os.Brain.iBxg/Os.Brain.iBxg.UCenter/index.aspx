<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%= System.Configuration.ConfigurationManager.AppSettings.Get("App_Title")%></title>
</head>
<frameset rows="64,*" frameborder="0" border="0" framespacing="0">
	<frame name="topFrame" noResize="true" frameBorder="0" marginWidth="0" marginHeight="0" scrolling="no" target="main" src="include/top.htm"/>
    <frameset cols="190,*" frameBorder="0" border="0" framespacing="0">
	    <frame name="leftFrame" noResize="true" frameBorder="0" marginWidth="0" marginHeight="0" scrolling="no" target="main" src="include/left.htm"/>
	    <frame name="main" noResize="true" frameBorder="0" marginWidth="0" marginHeight="0" scrolling="yes" target="_self" src="include/right.htm"/>
    </frameset>
</frameset>
<noframes>
    <body>
    

    </body>
</noframes>
</html>
