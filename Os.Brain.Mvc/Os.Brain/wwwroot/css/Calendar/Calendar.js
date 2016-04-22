/**
 * Page:Day Selecter
 * Code:Craze
 * Time:2009-5-22
 * Update:2009-6-4
 * Version:1.0
 * Description:2009-6-4调整  ifream 高度，样式兼容等 还待决绝firefox webdings字体问题
 *
 * Update:2009-09-09
 * Code:Craze
 * Description:2009-09-09调整内部input引用混乱问题，修改 $ 函数，可以传对象和字符串，调整响应事件，不比非得input，只要setHook()参数指向input就可以
 *
 *
 * Update:2009-11-13
 * Code:Craze
 * Description:2009-11-13优化函数结构，压缩不必要语句，待优化 替换掉 document.write
 *
 * Update:2010-8-10
 * Code:Craze
 * Description:2010-8-10放弃webdings字体改用图片，调整选择器随窗口大小出现的位置

 * Update:2014-11-19
 * Code:Craze
 * Description:2014-11-19调整正则表达式全局搜索日期格式，解决IE浏览器下，中午系统时间格式不正确的解析的异常
 *
 */

/**
----------- Example ----------------------------

<input type='text' name='someDateField' size='13' readonly='readonly' onclick='javascript:calendar.setHook(this)' />

*/

//时间扩展
Date.prototype.format=function(fmt) {
	var o = {
		"M+" : this.getMonth()+1,
		"d+" : this.getDate(),
		"h+" : this.getHours()%12 == 0 ? 12 : this.getHours()%12,
		"H+" : this.getHours(),
		"m+" : this.getMinutes(),
		"s+" : this.getSeconds(),
		"q+" : Math.floor((this.getMonth()+3)/3),
		"S" : this.getMilliseconds()
	}

	var week = {
		"0" : "\u65e5",
		"1" : "\u4e00",
		"2" : "\u4e8c",
		"3" : "\u4e09",
		"4" : "\u56db",
		"5" : "\u4e94",
		"6" : "\u516d"
	}

    if(/(y+)/.test(fmt))
        fmt=fmt.replace(RegExp.$1, (this.getFullYear()+"").substr(4 - RegExp.$1.length))

    if(/(E+)/.test(fmt))
        fmt=fmt.replace(RegExp.$1, ((RegExp.$1.length>1) ? (RegExp.$1.length>2 ? "\u661f\u671f" : "\u5468") : "")+week[this.getDay()+""]);

    for(var k in o)
        if(new RegExp("("+ k +")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length==1) ? (o[k]) : (("00"+ o[k]).substr((""+ o[k]).length)));

    return fmt;
}

//日历控件
function __Calendar(){
	this.isIE6=!!((/msie (\d+\.\d+)/i.test(navigator.userAgent) ? (document.documentMode || + RegExp['\x241']) : undefined)===6)
}

//每月含有天数
__Calendar.prototype.DaysInMonth=function(year,month){
	switch(month){
		case 1:
		case 3:
		case 5:
		case 7:
		case 8:
		case 10:
		case 12:return 31;
		case 4:
		case 6:
		case 9:
		case 11:return 30;
		case 2:if(year%400==0)return 29;if(year%4==0&&year%100!=0)return 29;return 28;
	}
}

//初始化日历控件
__Calendar.prototype.init = function () {
	this.week=(new Date(this.yyyy,this.MM-1,1)).getDay();
	this.days=this.DaysInMonth(this.yyyy,this.MM);
	var Text='<div id="CalendarBox"><table class="h"><tr><td class="tl fb">日历控件</td><td class="tr"><a href="javascript:calendar.setValue(\'\')">[擦除]</a> <a href="javascript:calendar.display()">[关闭]</a></td></tr></table><table class="c"><tr><td class="tl"><a href="javascript:calendar.prevYear()">&nbsp;</a>年<a class=\"right\" href="javascript:calendar.nextYear()">&nbsp;</a></td><td class="tc">'+this.yyyy+'年'+this.MM+'月</td><td class="tr"><a href="javascript:calendar.prevMonth()">&nbsp;</a>月<a class=\"right\" href="javascript:calendar.nextMonth()">&nbsp;</a></td></tr></table><table class="b"><tr><th>日</th><th>一</th><th>二</th><th>三</th><th>四</th><th>五</th><th>六</th></tr>'

	if(this.week!=0)
		Text+=this.week==1?'<tr><td class="cn"></td>':'<tr><td class="cn" colspan="'+this.week+'"></td>';

	for (var c = 1; c <= this.days; c++) {
	    if ((c + this.week) % 7 == 1)
	        Text += "<tr>";

	    if (this.yyyy == this.today.getFullYear() && this.MM == this.today.getMonth() + 1 && c == this.today.getDate())
	        Text += "<td class=\"cur\" onclick=\"calendar.setValue('" + this.yyyy + "-" + this.MM + "-" + c + "')\">" + c + "</td>";
	    else
	        Text += "<td onclick=\"calendar.setValue('" + this.yyyy + "-" + this.MM + "-" + c + "')\">" + c + "</td>";

	    if ((c + this.week) % 7 == 0)
	        Text += "</tr>"
	}

	if((this.days+this.week)%7!=0)
		Text+=(this.days+this.week)%7==6?'<td class="cn"></td></tr>':'<td class="cn" colspan="'+(7-(this.days+this.week)%7)+'"></td></tr>'
		Text+="</table></div>";
	return Text
};

//日历控件钩子
__Calendar.prototype.setHook=function(input){
	if(this.$("CalendarContainer").style.display!="none"&&this.input.id==input.id)
		this.display()
	else{
		this.input=input
		this.today = new Date;

		if(/^((((1[7-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[7-9]|[2-9]\d)\d{2})-(0?[469]|1[012])-(0?[1-9]|[12]\d|30))|(((1[7-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[7-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((17|[2468][048]|[3579][26])00))-0?2-29))$/.test(this.input.value)){
			input=this.input.value.split("-")
			this.yyyy=parseInt(input[0],10)
			this.MM=parseInt(input[1],10);
			this.dd=parseInt(input[2],10)
		}else{
			this.yyyy=this.today.getFullYear();
			this.MM=this.today.getMonth()+1
		}

		input=this.getOffset(this.input)

		with(this.$('CalendarContainer')){
			innerHTML  = this.init();
			style.display = ''
			if(input.x+this.$('CalendarContainer').offsetWidth<=this.size().w)
				style.left=input.x+'px'
			else if(this.size().w-this.$('CalendarContainer').offsetWidth<=0)
				style.left='0'
			else
				style.left=this.size().w-this.$('CalendarContainer').offsetWidth-3+'px'

			if(input.y+this.$('CalendarContainer').offsetHeight<=this.size().h)
				style.top=input.y+this.input.offsetHeight+5+'px'
			else if(this.size().h-this.$('CalendarContainer').offsetHeight<0)
				style.top='0'
			else
				style.top=this.size().h-this.$('CalendarContainer').offsetHeight-3+'px'
		}

		if(this.isIE6)
			with(this.$('CalendarContainerIfream').style){
				if(input.x+this.$('CalendarContainer').offsetWidth<=this.size().w)
					left=input.x+2+'px'
				else if(this.size().w-this.$('CalendarContainer').offsetWidth<=0)
					left='2px'
				else
					left=this.size().w-this.$('CalendarContainer').offsetWidth-1+'px'

				if(input.y+this.$('CalendarContainer').offsetHeight<=this.size().h)
					top=input.y+this.input.offsetHeight+7+'px'
				else if(this.size().h-this.$('CalendarContainer').offsetHeight<0)
					top='2px'
				else
					top=this.size().h-this.$('CalendarContainer').offsetHeight-1+'px'

				height=this.$('CalendarContainer').offsetHeight-4+'px';
				display = ''
			}
	}
}

__Calendar.prototype.prevYear=function(){
	this.yyyy--
	this.reset()
}

__Calendar.prototype.nextYear=function(){
	this.yyyy++
	this.reset()
}

__Calendar.prototype.prevMonth=function(){
	this.MM--
	if(this.MM<1){
		this.yyyy--
		this.MM=12
	}
	this.reset()
}

__Calendar.prototype.nextMonth=function(){
	this.MM++
	if(this.MM>12){
		this.yyyy++
		this.MM=1
	}
	this.reset()
}

__Calendar.prototype.reset=function(){
	this.$("CalendarContainer").innerHTML=this.init()
	if(this.isIE6)
		this.$("CalendarContainerIfream").style.height=this.$("CalendarContainer").offsetHeight-4+"px"
}

__Calendar.prototype.$=function(obj){
	return typeof obj=="string"?document.getElementById(obj):obj
}

__Calendar.prototype.display=function(){
	this.$("CalendarContainer").style.display="none"
	if(this.isIE6)
		this.$("CalendarContainerIfream").style.display="none"
}

__Calendar.prototype.setValue=function(date){
	if(''==date)
		this.input.value=date
	else
		this.input.value = (new Date(Date.parse(date.replace(/\-/ig,'/')))).format('yyyy-MM-dd');
	this.display()
}

__Calendar.prototype.getOffset=function(obj){
	for(var c=obj.offsetTop,d=obj.offsetLeft;obj=obj.offsetParent;){
		c+=obj.offsetTop;d+=obj.offsetLeft
	}
	return{x:d,y:c}
}

__Calendar.prototype.size=function(){
	var X=0,Y=0,width=0,height=0,cWidth=0,cHeight=0;

	if(typeof(window.pageXOffset)=='number'){
		X=window.pageXOffset;Y=window.pageYOffset
	}else if(document.body&&(document.body.scrollLeft||document.body.scrollTop)){
		X=document.body.scrollLeft;Y=document.body.scrollTop
	}else if(document.documentElement&&(document.documentElement.scrollLeft||document.documentElement.scrollTop)){
		X=document.documentElement.scrollLeft;Y=document.documentElement.scrollTop
	}

	if(typeof(window.innerWidth)=='number'){
		width=window.innerWidth;height=window.innerHeight
	}else if(document.documentElement&&(document.documentElement.clientWidth||document.documentElement.clientHeight)){
		width=document.documentElement.clientWidth;height=document.documentElement.clientHeight
	}else if(document.body&&(document.body.clientWidth||document.body.clientHeight)){
		width=document.body.clientWidth;height=document.body.clientHeight
	}

	if(document.documentElement&&(document.documentElement.scrollHeight||document.documentElement.offsetHeight)){
		if(document.documentElement.scrollHeight>document.documentElement.offsetHeight){
			cWidth=document.documentElement.scrollWidth;cHeight=document.documentElement.scrollHeight
		}else{
			cWidth=document.documentElement.offsetWidth;cHeight=document.documentElement.offsetHeight
		}
	}else if(document.body&&(document.body.scrollHeight||document.body.offsetHeight)){
		if(document.body.scrollHeight>document.body.offsetHeight){
			cWidth=document.body.scrollWidth;cHeight=document.body.scrollHeight
		}else{
			cWidth=document.body.offsetWidth;cHeight=document.body.offsetHeight
		}
	}else{
		cWidth=width;cHeight=height
	}

	if(height>cHeight)
		height=cHeight

	if(width>cWidth)
		width=cWidth
	return {
		ScrollX:		X,
		ScrollY:		Y,
		sx:				X,
		sy:				Y,
		width:			width,
		w:				width,
		height:			height,
		h:				height,
		contentWidth:	cWidth,
		cw:				cWidth,
		contentHeight:	cHeight,
		ch:				cHeight}
}


var calendar=new __Calendar;
document.write("<div id='CalendarContainer' style=\"display:none\"></div>");
calendar.isIE6&&document.write('<iframe id=\'CalendarContainerIfream\' style="display:none" frameborder="0"></iframe>');