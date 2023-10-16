import React from 'react'
import { Link } from 'react-router-dom'
import CustomCard from '../../models/CustomCard'
import './Card.css'
type Props = {
    cards: CustomCard[];
}

const Card = (props: Props) => {
  return (
    <>
                {
                props.cards.map((card, index) => {
                    return (
                        <div className="card p-2 col-lg-3 col-md-3 col-6" style={{border:"none"}}  key={index}>
                            <div className={'border shadow-sm '}>
                            <div className='bg-image '>
                                <img src={card.image} className="card-img-top zoom" alt={card.title} />
                            </div>

                            <div className="card-body">
                                <h5 className="card-title">{card.title}</h5>
                                <p className="card-text card-text_custom">
                                    {card.cardDescription}
                                </p>
                                <Link to={`/category/${card.title.toLowerCase()}`} className="btn btn-primary">
                                    Go to {card.title}
                                </Link>
                            </div>
                            </div>
                        </div>
                    );
                })
            }

    </>
  )
}
export default Card;