Ext.define('Demo.view.Main', {
    extend: 'Ext.navigation.View',
    xtype: 'mainview',
    
    requires: [
        'Demo.view.Menu',
        'Demo.view.List',
        'Demo.view.Form'
    ],
    
    config: {
        items: [
            { xtype: 'demomenu' }
        ]
    }
});