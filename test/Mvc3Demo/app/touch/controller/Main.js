Ext.define('Demo.controller.Main', {
    extend: 'Ext.app.Controller',
    
    config: {
        refs: {
            main: 'mainview',
            menu: 'demomenu',
            form: 'demoform',
            loadButton: 'demoform button[action=load]',
            saveButton: 'demoform button[action=save]'
        },
        control: {
            demomenu: {
                itemtap: 'onMenuItemTap',
                activate: 'onMenuActivate'
            },
            loadButton: {
                tap: 'loadForm'
            },
            saveButton: {
                tap: 'saveForm'
            }
        }
    },

    onMenuItemTap: function (list, index, target, record) {
        var item = Ext.create(record.get('xclass'));
        this.getMain().push(item);
    },
    
    onMenuActivate: function (list) {
        Ext.defer(list.deselectAll, 500, list);
    },

    loadForm: function () {
        Contact.Get(1, function (data, opts, success) {
            var contact = Ext.create('Demo.model.Contact', data);
            this.getForm().setRecord(contact);
        }, this);
    },

    saveForm: function () {
        // Unlike Ext JS in Sencha Touch 2 a Form cannot be submitted using Direct API,
        // therefore we have to manually call the method and pass form values.

        var form = this.getForm();
        var contact = form.getRecord();
        contact.set(form.getValues());
        
        Contact.Update(contact.data, function () {
            Ext.Msg.alert('Form', 'Contact saved!');
            Ext.getStore('Contacts').load();
        });
    }
});