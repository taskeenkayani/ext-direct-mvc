Ext.define('Test.controller.Main', {
    extend: 'Ext.app.Controller',
    
    config: {
        refs: {
            main: 'mainview',
            mainButton: '#mainButton',
            contactList: 'contact-list',
            contactView: {
                selector: 'contact-view',
                xtype: 'contact-view',
                autoCreate: true
            }
        },
        
        control: {
            main: {
                activeitemchange: 'onMainActiveItemChange'
            },
            contactList: {
                itemtap: 'onContactSelect'
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
            case 'contact-edit':
                mainButton.setText('Save');
                mainButton.setUi('confirm');
                break;
        }
    },
    
    onContactSelect: function (list, index, node, record) {
        var view = this.getContactView(); // contact view will be created if wasn't already
        view.setRecord(record);
        this.getMain().push(view);
    }
});