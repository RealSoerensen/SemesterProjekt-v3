import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import {faPhone} from '@fortawesome/free-solid-svg-icons'

type Props = {};

const Footer = (props: Props) => {
  const footerStyle: React.CSSProperties = {
    position: 'fixed',
    bottom: 0,
    width: '100%',
    backgroundColor: '#333',
    color: '#fff',
    padding: '10px 0',
    textAlign: 'center',
  };

  return (
    <footer style={footerStyle}>
      <div className="container">
        <p>&copy; {new Date().getFullYear()} Padel Shop</p>
        <p><FontAwesomeIcon icon={faPhone} />  Contact Patrick, out lead developer: 60513224  <FontAwesomeIcon icon={faPhone} flip="horizontal"/></p> {/* Add your phone number here */}
      </div>
    </footer>
  );
};

export default Footer;
