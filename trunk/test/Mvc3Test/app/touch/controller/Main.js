Ext.define('Test.controller.Main', {
    extend: 'Ext.app.Controller',
    
    config: {
        refs: {
            main: 'mainview',
            mainButton: '#mainButton',
            addButton: '#mainButton[text=Add]',
            editButton: '#mainButton[text=Edit]',
            saveButton: '#mainButton[text=Save]',
            contactList: 'contact-list',
            contactView: {
                selector: 'contact-view',
                xtype: 'contact-view',
                autoCreate: true
            },
            contactForm: {
                selector: 'contact-form',
                xtype: 'contact-form',
                autoCreate: true
            }
        },
        
        control: {
            main: {
                activeitemchange: 'onMainActiveItemChange'
            },
            contactList: {
                itemtap: 'onContactSelect'
            },
            addButton: {
                tap: 'onAddContact'
            },
            editButton: {
                tap: 'onEditContact'
            },
            saveButton: {
                tap: 'onSaveContact'
            }
        }
    },
    
    onMainActiveItemChange: function (mainview, item, oldItem) {
        var contactList = this.getContactList();
        var mainButton = this.getMainButton();
        
        switch (item.xtype) {
            case 'contact-list':
                Ext.defer(contactList.deselectAll, 500, contactList);
                mainButton.setText('Add');
                mainButton.setUi('normal');
                break;
            case 'contact-view':
                mainButton.setText('Edit');
                mainButton.setUi('normal');
                break;
            case 'contact-form':
                mainButton.setText('Save');
                mainButton.setUi('confirm');
                break;
        }
    },
    
    onContactSelect: function (list, index, node, record) {
        var view = this.getContactView(); // contact view will be created if wasn't already
        view.setRecord(record);
        this.getMain().push(view);
    },
    
    onAddContact: function () {
        console.log('onAddContact');
    },
    
    onEditContact: function () {
        var record = this.getContactView().getRecord();
        var form = this.getContactForm();
        form.setRecord(record);
        this.getMain().push(form);
    },

    onSaveContact: function () {
        var record = this.getContactForm().getRecord();
        console.log(record);
    }
});