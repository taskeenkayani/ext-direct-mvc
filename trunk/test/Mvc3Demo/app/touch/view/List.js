Ext.define('Demo.view.List', {
    extend: 'Ext.dataview.List',
    xtype: 'contact-list',
    
    config: {
        title: 'Contacts',
        store: 'Contacts',
        itemTpl: '{FirstName} {LastName}'
    }
});