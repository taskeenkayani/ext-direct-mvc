Ext.Loader.setConfig({
    enabled: true,
    paths: { 'Test': '/app/touch' }
});

Ext.Direct.addProvider(Ext.REMOTING_API);

Ext.application({
    name: 'Test',

    models: ['Contact'],
    stores: ['Contacts'],
    views: ['Main'],

    launch: function () {
        Ext.Viewport.add({
            xclass: 'Test.view.Main'
        });
    }
});