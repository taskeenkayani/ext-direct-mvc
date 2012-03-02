Ext.define('Test.view.contact.Form', {
    extend: 'Ext.form.Panel',
    xtype: 'contact-form',

    config: {
        title: 'Form',

        items: [{
            xtype: 'fieldset',
            items: [{
                xtype: 'textfield',
                name: 'FirstName',
                label: 'First Name'
            }, {
                xtype: 'textfield',
                name: 'LastName',
                label: 'Last Name'
            }, {
                xtype: 'emailfield',
                name: 'Email',
                label: 'Email'
            }, {
                xtype: 'datepickerfield',
                name: 'BirthDate',
                label: 'Birth Date',
                picker: {
                    yearFrom: 1900,
                    yearTo: new Date().getFullYear()
                }
            }]
        }]
    }
});