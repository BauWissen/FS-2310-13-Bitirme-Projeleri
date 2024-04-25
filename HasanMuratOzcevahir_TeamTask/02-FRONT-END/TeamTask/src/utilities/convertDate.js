export const convertDate = (date) => {
    const converted = new Date(date).toLocaleDateString("tr-TR", {
        year: 'numeric',
        month: 'long',
        day: 'numeric',
        hour :'numeric',
        minute :'numeric',
        second : 'numeric'
    })
    return converted
}