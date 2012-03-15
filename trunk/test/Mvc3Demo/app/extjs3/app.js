Ext.onReady(function () {
    Ext.BLANK_IMAGE_URL = 'http://cdn.sencha.io/ext-3.4.0/resources/images/default/s.gif';
    Ext.Direct.addProvider(Ext.REMOTING_API);
    Ext.QuickTips.init();

    var grid = new Ext.ux.ContactGrid({
        width: 500,
        height: 300,
        loadMask: true
    });
    grid.render('content');
});