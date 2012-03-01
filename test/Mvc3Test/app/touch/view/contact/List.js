Ext.define('Test.view.contact.List', {
    extend: 'Ext.dataview.List',
    xtype: 'contacts',
    
    config: {
        title: 'Contacts',
        store: 'Contacts',
        itemTpl: '{FirstName} {LastName}'
    }
});