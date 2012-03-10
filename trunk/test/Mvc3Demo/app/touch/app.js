Ext.Loader.setConfig({
    enabled: true,
    paths: { 'Demo': '/app/touch' }
});

Ext.direct.Manager.addProvider(Ext.REMOTING_API);

Ext.application({
    name: 'Demo',

    models: ['Contact'],
    stores: ['Contacts'],
    views: ['Main', 'Menu', 'Basic', 'List', 'Form'],
    controllers: ['Main'],

    launch: function () {
        Ext.Viewport.add({
            xclass: 'Demo.view.Main'
        });
    }
});