// Bug in Sencha Touch. Plugins don't get properly destroyedthe when the main component is destroyed.
Ext.define('Ext.plugin.ListPagingOverride', {
    override: 'Ext.plugin.ListPaging',
    updateList: function (list) {
        list.on('destroy', this.destroy, this);
    }
});

Ext.define('Demo.view.List', {
    extend: 'Ext.dataview.List',
    xtype: 'contactlist',
    
    config: {
        title: 'Contacts',
        store: 'Contacts',
        itemTpl: '{FirstName} {LastName}',
        grouped: true,
        plugins: 'listpaging'
    },
    
    initialize: function () {
        this.getStore().removeAll();
        this.callParent(arguments);
        this.getStore().loadPage(1);
    }
});