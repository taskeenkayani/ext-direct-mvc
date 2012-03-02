Ext.define('Test.view.Main', {
    extend: 'Ext.navigation.View',
    xtype: 'mainview',
    
    requires: [
        'Test.view.contact.List',
        'Test.view.contact.View',
        'Test.view.contact.Form'
    ],
    
    config: {
        autoDestroy: false,
        navigationBar: {
            items: [{
                xtype: 'button',
                id: 'mainButton',
                text: 'Add',
                align: 'right'
            }]
        },
        
        items: [
            { xtype: 'contact-list' }
        ]
    }
});