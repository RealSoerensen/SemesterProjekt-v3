import { Link } from 'react-router-dom'
import './Card.css'
import Image from '../Image'

export class CustomCard {
    image: string;
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

type Props = {
    cards: CustomCard[];
}

const Card = (props: Props) => {

    return (
        <>
            {
                props?.cards?.map((card, index) => {
                    return (
                        <div className="card p-2 col-lg-3 col-md-3 col-6" style={{ border: "none" }} key={index}>
                            <Link to={`${card.linkto}`} className="btn">
                                <div className='border shadow-sm rounded'>
                                    <div className='bg-image '>
                                        <Image image={card.image} imageTitle={card.title} className='card-img-top zoom' />
                                    </div>
                                    <div className="card-body">
                                        <h5 className="card-title">{card.title}</h5>
                                        <p className="card-text card-text_custom">
                                            {card.cardDescription}
                                        </p>
                                    </div>
                                </div>
                            </Link>
                        </div>
                    );
                })
            }

        </>
    )
}
export default Card;