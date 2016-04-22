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
 */

/**
----------- Example ----------------------------

<input type='text' name='someDateField' size='13' readonly='readonly' onclick='javascript:calendar.setHook(this)' />

*/



//日历控件
function __ColorPicker(){
	this.isIE6=!!(window.attachEvent&&navigator.userAgent.indexOf("Opera")===-1)&&parseFloat(navigator.userAgent.substring(navigator.userAgent.indexOf("MSIE ")+5,navigator.userAgent.indexOf(";",navigator.userAgent.indexOf("MSIE "))))<7
}


//初始化日历控件
__ColorPicker.prototype.init=function(){
	return '<div id="ColorBox"><table class="h"><tr><td class="tl fb">颜色控件</td><td class="tr"><a href="javascript:colorPicker.setValue(\'\')">[擦除]</a> <a href="javascript:colorPicker.display()">[关闭]</a></td></tr></table><div id="picker"></div></div>'
};

//日历控件钩子
__ColorPicker.prototype.setHook=function(input){
	this.input=input;
	var input1=input;
	if(input1.value=='')
		input1.value='#ffffff'

	input=this.getOffset(this.input)

	with(document.getElementById('ColorContainer')){
		innerHTML  = this.init();
		style.display = ''

		if(input.x+this.$('ColorContainer').offsetWidth<=this.size().w)
			style.left=input.x+'px'
		else if(this.size().w-this.$('ColorContainer').offsetWidth<=0)
			style.left='0'
		else
			style.left=this.size().w-this.$('ColorContainer').offsetWidth-3+'px'

		if(input.y+this.$('ColorContainer').offsetHeight<=this.size().h)
			style.top=input.y+this.input.offsetHeight+5+'px'
		else if(this.size().h-this.$('ColorContainer').offsetHeight<0)
			style.top='0'
		else
			style.top=this.size().h-this.$('ColorContainer').offsetHeight-3+'px'
	}

	$(document).ready(function() {$('#picker').farbtastic(input1)});
}

__ColorPicker.prototype.$=function(obj){
	return typeof obj=="string"?document.getElementById(obj):obj
}

__ColorPicker.prototype.display=function(){
	this.$("ColorContainer").style.display="none"
	if(this.isIE6)
		this.$("ColorContainerIfream").style.display="none"
}

__ColorPicker.prototype.setValue=function(date){
	this.input.value=''
	this.input.style.backgroundColor='#ffffff'
	this.display()
}

__ColorPicker.prototype.getOffset=function(obj){
	for(var c=obj.offsetTop,d=obj.offsetLeft;obj=obj.offsetParent;){
		c+=obj.offsetTop;d+=obj.offsetLeft
	}
	return{x:d,y:c}
}

__ColorPicker.prototype.size=function(){
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

var colorPicker=new __ColorPicker;
document.write("<div id='ColorContainer' style=\"display:none\"></div>");
colorPicker.isIE6&&document.write('<iframe id=\'ColorContainerIfream\' style="display:none" frameborder="0"></iframe>');