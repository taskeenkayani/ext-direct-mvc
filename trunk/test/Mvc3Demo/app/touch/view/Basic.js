Ext.define('Demo.view.Basic', {
    extend: 'Ext.Container',

    config: {
        title: 'Basic',
        layout: {
            type: 'vbox',
            pack: 'center'
        },
        defaults: {
            xtype: 'button',
            margin: 10
        },
        items: [
            {text: 'Echo Text'},
            {text: 'Echo Text'},
            {text: 'Echo Text'}
        ]
    }
});