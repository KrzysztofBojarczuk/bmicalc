import './App.css';
import {
    Button,
    Container,
    Row,
    Col,
    ListGroup,
    Form
} from 'react-bootstrap';
import {useState, useEffect} from 'react';
import axios from 'axios';

function App() {

    const [storeBody,
        setStoreBody] = useState([]);
    const [weight,
        setWeight] = useState("");
    const [height,
        setHeight] = useState("");

    useEffect(() => {
        const url = 'http://localhost:7187/api/Body'
        axios
            .get(url)
            .then(res => {
                console.log(res.data);
                setStoreBody(res.data);
            })

    }, [])

    const handleSubmit = (e) => {
        e.preventDefault();
        const newBody = {
            bodyId: Date.now(),
            weight,
            height
        };
        const url = 'http://localhost:7187/api/Body/Post'

        axios
            .post(url, newBody)
            .then((res) => {
                setStoreBody([
                    ...storeBody,
                    res.data
                ])
            })
            .catch((err) => {
                console.log(err);
            });
    };

    const handleDelete = (id) => {

        axios
            .delete(`http://localhost:7187/api/Body/Delete/${id}`,)
            .then(res => {
                setStoreBody(storeBody.filter((item) => item.bodyId !== id))
            })
            .catch(err => {
                console.log(err);
            })
    }

    return (
        <Container fluid="md">

            <Row className="mt-5">
                <Col
                    md={{
                    span: 6,
                    offset: 3
                }}>

                    <Form>
                        <Row className="mb-3">
                            <Form.Group as={Col}>
                                <Form.Label>Waga w kg</Form.Label>
                                <Form.Control
                                    type="number"
                                    value={weight}
                                    onChange={(e) => setWeight(e.target.value)}/>
                            </Form.Group>

                            <Form.Group as={Col}>
                                <Form.Label>Wzrost</Form.Label>
                                <Form.Control
                                    type="number"
                                    step="0.01"
                                    value={height}
                                    onChange={(e) => setHeight(e.target.value)}
                                    placeholder="1.70"/>
                            </Form.Group>
                        </Row>

                        <Button variant="primary" type="submit" onClick={handleSubmit}>
                            Submit
                        </Button>
                    </Form>
                </Col>
            </Row>

            <Row className="mt-5">
                <Col
                    md={{
                    span: 6,
                    offset: 3
                }}>

                    <ListGroup>
                        {storeBody.map((item) => {
                            return <div key={item.bodyId}>

                                <ListGroup.Item >

                                    <Row>

                                        <Col>
                                            Waga: {item.weight}</Col>

                                        <Col>
                                            Wzrost: {item.height}</Col>
                                        <Col>
                                            Bmi {item
                                                .bmi
                                                .toFixed(2)}</Col>
                                                <Col>
                                        <Button
                                           
                                            variant="primary"
                                            onClick={() => handleDelete(item.bodyId)}>
                                            Delete
                                        </Button>
                                                </Col>

                                    </Row>

                                </ListGroup.Item>
                            </div>
                        })}

                    </ListGroup>

                </Col>
            </Row>

        </Container>
    );
}

export default App;
