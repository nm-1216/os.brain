var LODOP;
function CheckIsInstall() {
    try {
        LODOP = getLodop();
        if (LODOP.VERSION) {
            if (LODOP.CVERSION)
                alert("当前有C-Lodop云打印可用!\n C-Lodop版本:" + LODOP.CVERSION + "(内含Lodop" + LODOP.VERSION + ")");
            else
                alert("本机已成功安装了Lodop控件！\n 版本号:" + LODOP.VERSION);
        };
    } catch (err) {
        alert(err)
    }
}

function Prn_Preview() {
    Prn_CallBack();
    LODOP.PREVIEW();
};

function Prn_Print() {
    Prn_CallBack();
    LODOP.PRINT();
};

function Prn_PrintA() {
    Prn_CallBack();
    LODOP.PRINTA();
};

function Prn_manage() {
    Prn_CallBack();
    LODOP.PRINT_SETUP();
};

function Prn_CallBack() {
    //LODOP = getLodop();
    //LODOP.PRINT_INITA("打印自来水发票");
    //LODOP.ADD_PRINT_SETUP_BKIMG("<img border='0' src='http://localhost:60888/images/1.jpg'>");
    //LODOP.SET_SHOW_MODE("BKIMG_LEFT", 0);
    //LODOP.SET_SHOW_MODE("BKIMG_TOP", 0);
    //LODOP.SET_SHOW_MODE("BKIMG_WIDTH", "183mm");
    ////LODOP.SET_SHOW_MODE("BKIMG_HEIGHT","99mm"); //这句可不加，因宽高比例固定按原图的
    //LODOP.SET_SHOW_MODE("BKIMG_IN_PREVIEW", 1);

    LODOP = getLodop();
    LODOP.PRINT_INIT("打印控件功能演示_Lodop功能_装载背景图");
    LODOP.ADD_PRINT_TEXT(83, 78, 75, 20, "寄件人姓名");
    LODOP.ADD_PRINT_TEXT(109, 137, 194, 20, "寄件人单位名称");
    LODOP.ADD_PRINT_TEXT(134, 90, 238, 35, "寄件人的详细地址");
    LODOP.ADD_PRINT_TEXT(85, 391, 75, 20, "收件人姓名");
    LODOP.ADD_PRINT_TEXT(108, 440, 208, 20, "收件人单位名称");
    LODOP.ADD_PRINT_TEXT(137, 403, 244, 35, "收件人详细地址");
    LODOP.ADD_PRINT_TEXT(252, 33, 164, 40, "内件品名");
    LODOP.ADD_PRINT_TEXT(261, 221, 100, 20, "内件数量");
    LODOP.ADD_PRINT_TEXT(83, 212, 100, 20, "寄件人电话");
    LODOP.ADD_PRINT_TEXT(80, 554, 75, 20, "收件人电话");

    LODOP.ADD_PRINT_SETUP_BKIMG("<img border='0' src='http://localhost:60888/images/1.jpg'>");
    LODOP.SET_SHOW_MODE("BKIMG_PRINT", 1);
    //LODOP.PREVIEW();
};