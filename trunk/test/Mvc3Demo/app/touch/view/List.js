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
        }],
        listeners: {
            destroy: 'onDestroy'
        }
    },
    
    initialize: function () {
        this.getStore().removeAll();
        this.callParent(arguments);
        this.getStore().loadPage(1);
    },
    
    onDestroy: function () {
        // Bug in Sencha Touch. Plugins don't get properly destroyed.
        this.getPlugins()[0].destroy();
    }
});