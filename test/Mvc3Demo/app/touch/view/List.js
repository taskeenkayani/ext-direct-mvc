Ext.define('Demo.view.List', {
    extend: 'Ext.dataview.List',
    xtype: 'contactlist',
    
    config: {
        title: 'Contacts',
        store: 'Contacts',
        itemTpl: '{FirstName} {LastName}',
        grouped: true,
        plugins: [{
            xclass: 'Ext.plugin.ListPaging'
        }]
    },
    
    initialize: function () {
        this.callParent(arguments);
        this.getStore().loadPage(1);
    }
});