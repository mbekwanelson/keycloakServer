FROM quay.io/keycloak/keycloak:latest

ENV KEYCLOAK_ADMIN=admin

ENTRYPOINT ["/opt/keycloak/bin/kc.sh", "start-dev"]