export class Inspection {
    public id: number;
    public inspectionDate: Date;
    public customer: string;
    public observations: string;
    public status: string;
    public inspector: Inspector;
    constructor(attributes: Inspection = null) {
        switch (attributes.status) {
            case '1': {
               attributes.status = 'New';
               break;
            }
            case '2': {
                attributes.status = 'In Progress';
                break;
             }
             case '2': {
                attributes.status = 'Done';
                break;
             }
         }
         console.log('atributes', attributes);
         Object.assign(this, attributes);
    }
}

export class Inspector {
    public id: number;
    public inspectorName: string;

     constructor(attributes: Inspector = null) {
          Object.assign(this, attributes);
     }
}
