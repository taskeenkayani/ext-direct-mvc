Ext.ux.BasicTree = Ext.extend(Ext.tree.TreePanel, {
    title: 'Basic Tree Panel',
    autoScroll: true,
    padding: 5,
    bodyStyle: {
        backgroundColor: '#ffffff',
        border: 'solid 1px #99BBE8'
    },
    
    initComponent: function() {
        var config = {
            loader: new Ext.tree.TreeLoader({
                directFn: Tree.Load
            }),
            root: {
                id: 'root',
                text: 'Root'
            },
            bbar: [{
                text: 'Reload',
                handler: function() {
                    this.getRootNode().reload();
                },
                scope: this
            }]
        };
        
        Ext.apply(this, Ext.apply(this.initialConfig, config));
        
        Ext.ux.BasicTree.superclass.initComponent.call(this);
    }
});

Ext.reg('basictree', Ext.ux.BasicTree);