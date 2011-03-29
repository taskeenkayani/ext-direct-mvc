Ext.ns('Demo');

Ext.onReady(function () {
    Ext.BLANK_IMAGE_URL = 'http://extjs.cachefly.net/ext-3.3.1/resources/images/default/s.gif';
    //Ext.Direct.addProvider(Ext.app.REMOTING_API);
    Ext.QuickTips.init();

    Ext.Msg.alert('Mvc3Demo', 'Application initialized.');
});