import clsx from 'clsx';
import Link from '@docusaurus/Link';
import useDocusaurusContext from '@docusaurus/useDocusaurusContext';
import Layout from '@theme/Layout';
import Heading from '@theme/Heading';

import styles from './index.module.css';

const features = [
  {
    icon: '🗺️',
    title: 'Interactive Map View',
    description:
      'Visualise all your photos on an interactive Bing Maps map. Each photo is pinned at the exact GPS coordinates it was taken, giving you a beautiful geographic overview of your collection.',
  },
  {
    icon: '📍',
    title: 'GPS Coordinate Extraction',
    description:
      'Automatically reads GPS EXIF metadata embedded in your photos. No manual tagging required — if the camera or phone recorded the location, Photo Locator will find it.',
  },
  {
    icon: '🔍',
    title: 'Smart Filtering',
    description:
      'Quickly find photos by address or index number with the built-in filter. Search is instant and case-insensitive, making it easy to locate photos from a specific place.',
  },
  {
    icon: '📋',
    title: 'CSV Export',
    description:
      'Export all photo details — including filename, address, date taken, latitude and longitude — to a semi-colon delimited CSV file for further analysis or archiving.',
  },
  {
    icon: '✏️',
    title: 'Smart Renaming',
    description:
      'Rename all photos at once to the descriptive format "Date Time Address". Files are never overwritten thanks to automatic conflict resolution.',
  },
  {
    icon: '🖼️',
    title: 'Photo Preview',
    description:
      'Click any photo in the list to open it with your default image viewer. Thumbnails are displayed inline with automatic rotation correction for portrait shots.',
  },
];

const stats = [
  { value: 'Free', label: 'For personal use' },
  { value: '6+', label: 'Powerful features' },
  { value: '.NET', label: 'Windows desktop app' },
  { value: 'EXIF', label: 'GPS metadata support' },
];

function HeroBanner() {
  return (
    <div className={styles.heroBanner}>
      <div className="container">
        <div className={styles.heroBadge}>
          📸 Windows Desktop App
        </div>
        <Heading as="h1">
          Know Where Every<br />Photo Was Taken
        </Heading>
        <p>
          Photo Locator is a free, easy-to-use Windows application that reads GPS
          metadata from your photos and displays their locations on an interactive map.
          Explore, filter, export and organise your photo collection by location.
        </p>
        <div className={styles.heroButtons}>
          <Link
            className="button button--secondary button--lg"
            to="https://github.com/mzbrau/photo-locator/raw/master/Releases/1.0/Photo%20Locator.msi"
          >
            ⬇️ Download v1.0
          </Link>
          <Link
            className="button button--outline button--lg"
            to="/docs/intro"
            style={{ color: 'white', borderColor: 'rgba(255,255,255,0.7)' }}
          >
            📖 Read the Docs
          </Link>
        </div>
      </div>
    </div>
  );
}

function StatsSection() {
  return (
    <div className={styles.statsSection}>
      <div className="container">
        <div className={styles.statsGrid}>
          {stats.map(({ value, label }) => (
            <div key={label} className={styles.statItem}>
              <h3>{value}</h3>
              <p>{label}</p>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}

function FeaturesSection() {
  return (
    <section className={styles.features}>
      <div className="container">
        <div className="text--center margin-bottom--xl">
          <Heading as="h2">Everything You Need</Heading>
          <p className="hero__subtitle" style={{ color: 'var(--ifm-color-emphasis-700)' }}>
            A complete toolkit for location-aware photo management on Windows.
          </p>
        </div>
        <div className={styles.featureGrid}>
          {features.map(({ icon, title, description }) => (
            <div key={title} className={styles.featureCard}>
              <div className={styles.featureIcon}>{icon}</div>
              <h3>{title}</h3>
              <p>{description}</p>
            </div>
          ))}
        </div>
      </div>
    </section>
  );
}

function CtaSection() {
  return (
    <section className={styles.ctaSection}>
      <div className="container">
        <Heading as="h2">Ready to Explore Your Photos?</Heading>
        <p>
          Download Photo Locator for free and start discovering where your memories were made.
        </p>
        <div className={styles.ctaButtons}>
          <Link
            className="button button--primary button--lg"
            to="/docs/getting-started"
          >
            🚀 Get Started
          </Link>
          <Link
            className="button button--secondary button--lg"
            to="https://github.com/mzbrau/photo-locator"
          >
            View on GitHub
          </Link>
        </div>
      </div>
    </section>
  );
}

export default function Home() {
  const { siteConfig } = useDocusaurusContext();
  return (
    <Layout
      title={siteConfig.title}
      description="Photo Locator — visualise where your photos were taken on an interactive map. Free Windows desktop app."
    >
      <HeroBanner />
      <main>
        <StatsSection />
        <FeaturesSection />
        <CtaSection />
      </main>
    </Layout>
  );
}
