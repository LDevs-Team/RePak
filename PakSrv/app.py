"""
This script runs the application using a development server.
It contains the definition of routes and views for the application.
"""

import time
from flask import Flask, jsonify
app = Flask(__name__)

# Make the WSGI interface available at the top level so wfastcgi can get it.
wsgi_app = app.wsgi_app


@app.route('/')
def hello():
    """Renders a sample page."""
    return jsonify({"packages": [{"name":"DiSH", "download_url": "http://example.com", "screenshots": [], "description": "DiscordSHell", "imageUrl": "https://i.imgur.com/FUhgvl3.png"}, {"name": "DiSHLoader", "download_url": "https://example.com", "screenshots":[], "description": "Loader for DiSH", "imageUrl": "https://i.imgur.com/3u8TEbm.png"}]})

if __name__ == '__main__':
    import os
    HOST = os.environ.get('SERVER_HOST', 'localhost')
    try:
        PORT = int(os.environ.get('SERVER_PORT', '5555'))
    except ValueError:
        PORT = 5555
    app.run(HOST, PORT)
