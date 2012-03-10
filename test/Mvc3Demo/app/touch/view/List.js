Ext.define('Demo.view.List', {
    extend: 'Ext.dataview.List',
    xtype: 'contactlist',
    
    config: {
        title: 'Contacts',
        store: 'Contacts',
        itemTpl: '{FirstName} {LastName}'
    }
});