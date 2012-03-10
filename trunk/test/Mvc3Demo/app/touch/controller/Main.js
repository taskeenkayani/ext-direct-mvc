Ext.define('Demo.controller.Main', {
    extend: 'Ext.app.Controller',
    
    config: {
        refs: {
            main: 'mainview',
            menu: 'demomenu'
        },
        control: {
            demomenu: {
                itemtap: 'onMenuItemTap'
            }
        }
    },

    onMenuItemTap: function (list, index, target, record) {
        var item = Ext.create(record.get('class'));
        this.getMain().push(item);
    }
});