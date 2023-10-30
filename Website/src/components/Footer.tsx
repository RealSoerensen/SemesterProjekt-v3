import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { icon } from '@fortawesome/fontawesome-svg-core/import.macro';
import { useState } from 'react';
import { Link } from 'react-router-dom';

const Footer = () => {
    const fbIcon = icon({ name: 'facebook', style: 'brands' });
    const instaIcon = icon({ name: 'instagram', style: 'brands' });
    const twitterIcon = icon({ name: 'twitter', style: 'brands' });

    const [icons] = useState([fbIcon, instaIcon, twitterIcon]);

    return (
        <footer className="bg-dark text-light">
            <div className="container-fluid pt-4">
                <div className="row">
                    <div className="col-md-4">
                        <h3>Om os</h3>
                        <p>
                            Grundlagt i 2023, er Padel Shop meget nyt på padeltennis markedet, men ser allerede
                            stor fremtræden og efterspørgsel hos kunderne.
                        </p>
                        <Link to="/about" className="text-light">Læs mere om os her</Link>
                    </div>
                    <div className="col-md-4">
                        <h3>Kontakt os</h3>
                        <p>Hindsholmvej 98</p>
                        <p>5853 Ørbæk, Danmark</p>
                        <p><a href="tel:+45 12 34 56 78" className="text-light">+45 12 34 56 78</a></p>
                        <p><a href="mailto:info@padelshop.dk" className="text-light">kontakt@padelshop.dk</a></p>
                    </div>
                    <div className="col-md-4">
                        <h3>Følg os</h3>
                        <div className="row">
                            {
                                icons.map((icon, index) => {
                                    return (
                                        <div className="col-12 mb-3" key={index}>
                                            <Link className='text-light d-flex align-items-center' to={`https://www.${icon.iconName}.com`} target="_blank" rel="noopener noreferrer">
                                                <FontAwesomeIcon icon={icon} size="2x" />
                                                <p className="d-inline ms-2">På {icon.iconName}</p>
                                            </Link>
                                        </div>
                                    )
                                })
                            }
                        </div>
                    </div>
                    <div className="row">
                        <div className="col-md-12">
                            <hr />
                            <p className="text-center">&copy; {new Date().getFullYear()} Padel Shop</p>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
    );
};

export default Footer;
