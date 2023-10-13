import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { icon } from '@fortawesome/fontawesome-svg-core/import.macro';

const Footer = () => {

  const phoneIcon = icon({ name: 'phone', family: 'classic', style: 'solid' });

  return (
    <footer className='bg-dark text-center text-light fixed-bottom'>
      <div className="container mt-3">
        <p>&copy; {new Date().getFullYear()} Padel Shop</p>
        <p>
          <FontAwesomeIcon icon={phoneIcon} />
          Contact Patrick, our lead developer: <a href="tel:+4560513224">60513224</a>
          <FontAwesomeIcon icon={phoneIcon} flip="horizontal" />
        </p>
      </div>
    </footer>
  );
};

export default Footer;
