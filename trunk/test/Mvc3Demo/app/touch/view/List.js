// Bug in Sencha Touch. Plugins don't get properly destroyed with the main component.
// http://www.sencha.com/forum/showthread.php?188236-Plugins-are-not-destroyed-properly-for-extended-components.
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