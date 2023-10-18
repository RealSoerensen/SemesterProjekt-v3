import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { icon } from '@fortawesome/fontawesome-svg-core/import.macro';

const Footer = () => {

    const phoneIcon = icon({ name: 'phone', family: 'classic', style: 'solid' });

    return (
        <footer className='bg-dark text-center text-light'>
            <div className="container mt-3 mb-0 pb-0">
                <p className='p-0' >&copy; {new Date().getFullYear()} Padel Shop</p>
                <p className='p-0 m-0'>
                    <FontAwesomeIcon icon={phoneIcon} />
                    Contact Patrick, our lead developer: <a href="tel:+4560513224">60513224</a>
                    <FontAwesomeIcon icon={phoneIcon} flip="horizontal" />
                </p>
            </div>
        </footer>
    );
};

export default Footer;