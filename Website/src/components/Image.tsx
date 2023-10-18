import React, { useEffect } from 'react'
import { useState } from 'react'
type Props = {
    image: string;
    imageTitle: string;
    className:string;
}
    


const Image = (props:Props) => {
    const [image, setImage] = useState<string>("");
    useEffect(() => {
        console.log(props.image)
        if(props?.image?.length>200){
            setImage(`data:image/jpeg;base64,${props.image}`);
        }else{
            setImage(props.image)
        }        
    },[image])
  return (
    <img className={props.className} src={image} alt={props.imageTitle}/>
  )
}

export default Image
