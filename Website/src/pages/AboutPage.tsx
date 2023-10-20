import React from "react";
import { useState } from 'react';

//images
import padelabout from '../content/images/padelabout.jpg'
import dogpicture from '../content/images/dogpicture.jpg'

class Employee {
    name: string;
    img: string;
    constructor(name: string, img: string) {
        this.name = name;
        this.img = img;

    }
}

const About: React.FC = () => {
    const [employees] = useState<Employee[]>([
        new Employee("Jonas", dogpicture),
        new Employee("Filip", dogpicture),
        new Employee("Svend", dogpicture),
        new Employee("Patrick", dogpicture)
    ])


    return (
        <div className="container">
            <div className="row">
                <h1 className="col-12">About</h1>
                <p className="col-sm-12 col-md-6">
                    Her finder du information om Padel Shop og hvad vi står for. <br /> <br />
                    Padel Shop er en lille gruppe af 4 individer, der søger at få mere fokus på padeltennis. Grundlagt i 2023, er Padel Shop meget nyt på padeltennis markedet, men ser allerede
                    stor fremtræden og efterspørgsel hos kunderne. Padel Shop består af Patrick, Filip, Svend og Jonas, der alle er tidligere store sportsfolk,
                    og gennem deres karriere har dannet samarbejdet, der er blevet til Padel Shop. Padel Shop tror på, at aktivitet og motion
                    er vejen til et bedre liv, og kan bringe gode bekendtskaber og fællesskaber at være del af. <br /> <br />
                    Vi går efter at være både troværdige og have de bedste tilbud til vores kunder. Hos Padel Shop kommer kunden altid først, og vil altid
                    være en del af den succes, som Padel Shop opnår. Derfor søger vi altid efter de bedste løsninger for kunderne, så vi sikrer vores kunders tilfredshed.
                </p>
                <img src={padelabout} alt="PadelAbout" className="img-fluid object-fit-cover col-sm-12 col-md-6" style={{ maxHeight: '400px' }} />
                <h2 className="col-12 mt-3">Målgruppe</h2>
                <p className="col-12">Målgruppen for Padel Shop er aktive folk, der spiller padeltennis. Padel Shop yder kvalitet i deres produkter og giver spilleren det
                    perfekte udstyr til lige præcis deres behov. Om det er den professionelle turneringsspiller eller motionisten, der savner kvaliteten og sikkerheden i
                    eget udstyr. Padel Shop har noget til enhver padeltennis entusiast.
                </p>
                <h2 className="col-12 text-center mt-5">Medlemmer</h2>

                {
                    employees.map((employee, index) => {
                        return (
                            <div className="col-sm-12 col-md-3" key={index}>
                                <img src={employee.img} alt={employee.name} className="mx-auto d-block img-fluid object-fit-cover col-12 rounded-circle" style={{ maxHeight: '200px', width: '200px' }} />
                                <h5 className="text-center">{employee.name}</h5>

                            </div>
                        )
                    })
                }

            </div>
        </div>


    );
};

export default About;
