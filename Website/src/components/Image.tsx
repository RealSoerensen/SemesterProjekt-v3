import { useEffect, useState } from 'react'
type Props = {
    image: string;
    imageTitle: string;
    className: string;
}



const Image = (props: Props) => {
    const [image, setImage] = useState<string>("");
    useEffect(() => {
        if (props?.image?.length > 200) {
            setImage(`data:image/jpeg;base64,${props.image}`);
        } else {
            setImage(props.image)
        }
    }, [props.image])
    return (
        <img className={props.className} src={image} alt={props.imageTitle} />
    )
}

export default Image

