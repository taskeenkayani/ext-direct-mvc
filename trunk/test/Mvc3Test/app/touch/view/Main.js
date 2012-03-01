Ext.define('Test.view.Main', {
    extend: 'Ext.navigation.View',
    xtype: 'mainview',
    
    requires: [
        'Test.view.contact.List',
        'Test.view.contact.View'
    ],
    
    config: {
        autoDestroy: false,
        navigationBar: {
            items: [
                {
                    xtype: 'button',
                    id: 'addButton',
                    text: 'Add',
                    align: 'right'
                }
            ]
        },
        
        items: [
            { xtype: 'contacts' }
        ]
    }
});