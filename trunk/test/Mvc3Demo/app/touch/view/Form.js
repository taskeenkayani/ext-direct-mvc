Ext.define('Demo.view.Form', {
    extend: 'Ext.form.Panel',
    xtype: 'demoform',

    config: {
        title: 'Form',
        items: [
            {
                xtype: 'fieldset',
                title: 'Contact Information',
                instructions: 'Tap Load to load a contact, then make some changes and tap Save.',
                defaults: {
                    labelWidth: '6em'
                },
                items: [
                    {
                        xtype: 'textfield',
                        label: 'First Name',
                        name: 'FirstName'
                    },
                    {
                        xtype: 'textfield',
                        label: 'Last Name',
                        name: 'LastName'
                    },
                    {
                        xtype: 'emailfield',
                        label: 'Email',
                        name: 'Email'
                    },
                    {
                        xtype: 'datepickerfield',
                        label: 'Birth Date',
                        name: 'BirthDate',
                        picker: {
                            yearFrom: 1900,
                            yearTo: new Date().getFullYear()
                        }
                    },
                    {
                        xtype: 'checkboxfield',
                        label: 'Favourite',
                        name: 'IsFavourite'
                    }
                ]
            },
            {
                xtype: 'container',
                layout: 'hbox',
                items: [
                    {
                        xtype: 'button',
                        text: 'Load',
                        action: 'load',
                        align: 'left',
                        flex: 1
                    },
                    {
                        xtype: 'spacer',
                        width: '1em'
                    },
                    {
                        xtype: 'button',
                        text: 'Save',
                        action: 'save',
                        ui: 'confirm',
                        align: 'right',
                        flex: 1
                    }
                ]
            }
        ]
    }
})