Ext.define('Demo.view.Main', {
    extend: 'Ext.navigation.View',
    xtype: 'mainview',
    
    config: {
        items: [
            { xtype: 'demomenu' }
        ]
    }
});