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
                itemtap: 'onMenuItemTap'
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
        var item = Ext.create(record.get('class'));
        this.getMain().push(item);
    },

    loadForm: function () {
        Contact.Get(1, function (data, opts, success) {
            var contact = Ext.create('Demo.model.Contact', data);
            this.getForm().setRecord(contact);
        }, this);
    },

    saveForm: function () {
        var form = this.getForm();
        var contact = form.getRecord();
        contact.set(form.getValues());
        
        Contact.Update(contact.data, function () {
            Ext.Msg.alert('Form', 'Contact saved!');
            Ext.getStore('Contacts').load();
        });
    }
});