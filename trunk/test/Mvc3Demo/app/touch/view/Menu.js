Ext.define('Demo.view.Menu', {
    extend: 'Ext.dataview.List',
    xtype: 'demomenu',

    config: {
        title: 'Menu',
        ui: 'round',
        store: {
            fields: ['text', 'xclass'],
            proxy: {
                type: 'memory'
            },
            data: [
                {text: 'List', xclass: 'Demo.view.List'},
                {text: 'Form', xclass: 'Demo.view.Form'}
            ]
        }
    }
});