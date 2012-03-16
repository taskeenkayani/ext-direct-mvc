Ext.define('Demo.store.Tree', {
    extend: 'Ext.data.TreeStore',
    root: {
        expanded: false
    },
    proxy: {
        type: 'direct',
        directFn: Tree.Load,
        paramOrder: 'node'
    }
});