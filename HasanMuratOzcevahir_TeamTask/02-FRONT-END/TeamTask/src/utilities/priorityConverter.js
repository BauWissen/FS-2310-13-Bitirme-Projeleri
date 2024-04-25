let priorityObj = {
    color: null,
    text: null
}
export const priorityConverter = (priority) => {

    switch (priority) {
        case 0:
            priorityObj.color = '#ff6600'
            priorityObj.text = 'Yüksek'
            return priorityObj
        case 1:
            priorityObj.color = '#d9cfc4'
            priorityObj.text = 'Normal'
            return priorityObj
        case 2:
            priorityObj.color = '#ffcc99'
            priorityObj.text = 'Düşük'
            return priorityObj

        default:
            return priorityObj
           
    }

}