class CustomCard {
    image :string;
    title: string;
    cardDescription: string;
    linkto: string;
    constructor(image: string, title: string, cardDescription: string, linkto: string ) {
        this.image = image;
        this.title = title;
        this.cardDescription = cardDescription;
        this.linkto = linkto;
        
    }
}
export default CustomCard;