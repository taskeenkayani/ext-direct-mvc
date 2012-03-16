Ext.define('Demo.view.Tree', {
    extend: 'Ext.tree.Panel',
    title: 'Basic Tree',
    store: 'Tree',
    bbar: [{
        text: 'Reload',
        itemId: 'reloadButton'
    }],
    
    initComponent: function () {
        this.callParent(arguments);

        this.down('#reloadButton').on('click', function() {
            this.getStore().load();
        }, this);
    }
});